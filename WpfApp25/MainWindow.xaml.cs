using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using FluentValidation;

namespace WpfApp25 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        DispatcherTimer timer;
        TimeSpan time;

        public MainWindow() {
            InitializeComponent();

            var executeQueries = new List<Func<CancellationToken, Task<ICollection<Group>>>>();

            var domains = new List<string> {
                "domain 1", "domain 2"
            };

            domains.ForEach(domain =>
                executeQueries.Add(async (ct) =>
                    await ExecuteQueryGroupsForDomain(domain, 123, ct)));

            Expression<Func<CancellationToken, string, Task<ICollection<Group>>>> expr = (token, domain) =>
                this.ExecuteQueryGroupsForDomain(domain, 123, token);

            var abc = expr.Compile()(CancellationToken.None, "abc");

            foreach (var domain in domains) {
                executeQueries.Add(token => this.ExecuteQueryGroupsForDomain(domain, 123, token));
            }
            executeQueries.AddRange(domains
                .Select(domain => (Func<CancellationToken, Task<ICollection<Group>>>) (token => 
                    this.ExecuteQueryGroupsForDomain(domain, 123, token))));
            executeQueries =
                (from domain in domains
                select new Func<CancellationToken, Task<ICollection<Group>>>(token => 
                    this.ExecuteQueryGroupsForDomain(domain, 123, token))).ToList();




            //var executeQueries2 = domains.Select(domain =>
            //    (async (ct) => await ExecuteQueryGroupsForDomain(domain, 123, ct)));
            //var executeQueries2 = domains.Select(domain =>
            //    (async (CancellationToken ct) => { return await ExecuteQueryGroupsForDomain(domain, 123, ct); }));

            executeQueries = domains.Select(domain => 
                new Func<CancellationToken, Task<ICollection<Group>>>(token => 
                    this.ExecuteQueryGroupsForDomain(domain, 123, token))).ToList();
            executeQueries = domains.Select<string, Func<CancellationToken, Task<ICollection<Group>>>>(domain =>
                ct => this.ExecuteQueryGroupsForDomain(domain, 123, ct)).ToList();
                



            //MessageBox.Show($"{int.Parse(outS)}");


            //MessageBox.Show($"{int.Parse(outS)}\n" +
            //                $"{Metodo1(length)}");
        }


        private async Task<ICollection<Group>> ExecuteQueryGroupsForDomain(string domain, int i, CancellationToken ct) {
            return new List<Group> {
                new Group()
            };
        }

        private int Metodo1(int length) => new Random().Next((int)Math.Pow(10, length - 1), (int)Math.Pow(10, length));

        private int Metodo2(int length) {
            var outS = "";
            var random = new Random();
            for (int i = 0; i < length; i++) {
                outS += random.Next(0, 9).ToString();
            }

            return int.Parse(outS);
        }

        //private async void AppearingNext() {
        //    await Task.Delay(TimeSpan.FromSeconds(10));
        //    VisibilityPanel.Visibility = Visibility.Visible;

        //}
    }

    public class Group { }

    public class MyClassToValidate {
        public string Name { get; set; }
    }

    public class MyClassToValidateValidator : AbstractValidator<MyClassToValidate> {
        public MyClassToValidateValidator(IMyClassToValidateRepository repository) {
            RuleFor(x => x.Name)
                .MustAsync(async (name, ct) => 
                    (await repository.GetDataAsync()).All(x => x.Name != name));
        }
    }

    public interface IMyClassToValidateRepository {
        Task<IList<MyClassToValidate>> GetDataAsync();
    }
}
