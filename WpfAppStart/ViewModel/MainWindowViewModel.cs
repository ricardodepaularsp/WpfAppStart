using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfAppStart.ViewModel
{
    public class MainWindowViewModel
    {
        public ObservableCollection<MainWindowModel> Orders { get; private set; }
        private object _OrdersLock = new object();
        public bool Stop { get; set; }


        public MainWindowViewModel()
        {
            this.Stop = false;
            Orders = new ObservableCollection<MainWindowModel>();

            BindingOperations.EnableCollectionSynchronization(Orders, _OrdersLock);

            this.startThreadXP();
            this.startAlteraThreadXP();
        }
        public bool startThreadXP()
        {
            #region Dashboard
            Thread ThreadDash = new Thread(() => ThreadXP());
            ThreadDash.SetApartmentState(System.Threading.ApartmentState.STA);
            ThreadDash.IsBackground = true;
            ThreadDash.Priority = System.Threading.ThreadPriority.Lowest;
            ThreadDash.Start();
            return true;
            #endregion
        }

        public bool startAlteraThreadXP()
        {
            #region Dashboard
            Thread ThreadDash = new Thread(() => ThreadAlteraXP());
            ThreadDash.SetApartmentState(System.Threading.ApartmentState.STA);
            ThreadDash.IsBackground = true;
            ThreadDash.Priority = System.Threading.ThreadPriority.Lowest;
            ThreadDash.Start();
            return true;
            #endregion
        }

        public bool ThreadXP()
        {
            long num = 0;
            while (true)
            {
                try
                {
                    if (this.Stop)
                    {
                        Thread.CurrentThread.Abort();
                        break;
                    }

                    lock (_OrdersLock)
                    {
                        Orders.Add(new MainWindowModel()
                        {
                            DataHora = DateTime.Now,
                            Assessor = RandomString(20),
                            Ativo = RandomString(1),
                            Conta = ++num,
                            ObjDisp = Convert.ToDecimal(RandomNumber(9)),
                            Objetivo = Convert.ToDecimal(RandomNumber(9)),
                            Qtd = Convert.ToInt32(RandomNumber(3)),
                            QtdAparente = Convert.ToInt32(RandomNumber(3)),
                            QtdCancel = Convert.ToInt32(RandomNumber(3)),
                            QtdDisp = Convert.ToInt32(RandomNumber(3)),
                            QtdExec = Convert.ToInt32(RandomNumber(9)),
                            Reducao = Convert.ToDecimal(RandomNumber(9)),
                            Tipo = RandomString(1),
                            Valor = Convert.ToDecimal(RandomNumber(9)),
                            ValorDisp = Convert.ToDecimal(RandomNumber(9)),
                            IndicaAlterado = false
                        });
                    }


                }
                catch (Exception ex)
                {
                    return false;
                }

                Thread.Sleep(TimeSpan.FromMilliseconds(50));

            }
            return true;
        }

        public bool ThreadAlteraXP()
        {
            long num = 0;
            while (true)
            {
                try
                {
                    if (this.Stop)
                    {
                        Thread.CurrentThread.Abort();
                        break;
                    }

                    lock (_OrdersLock)
                    {
                        decimal valor = Convert.ToDecimal(RandomNumber(9));
                        foreach (var item in Orders.Where(f => f.Valor >= valor))
                        {

                            item.DataHora = DateTime.Now;
                            item.Assessor = RandomString(20);
                            item.Ativo = RandomString(1);
                            item.Conta = ++num;
                            item.ObjDisp = Convert.ToDecimal(RandomNumber(9));
                            item.Objetivo = Convert.ToDecimal(RandomNumber(9));
                            item.Qtd = Convert.ToInt32(RandomNumber(3));
                            item.QtdAparente = Convert.ToInt32(RandomNumber(3));
                            item.QtdCancel = Convert.ToInt32(RandomNumber(3));
                            item.QtdDisp = Convert.ToInt32(RandomNumber(3));
                            item.QtdExec = Convert.ToInt32(RandomNumber(9));
                            item.Reducao = Convert.ToDecimal(RandomNumber(9));
                            item.Tipo = RandomString(1);
                            item.Valor = Convert.ToDecimal(RandomNumber(9));
                            item.ValorDisp = Convert.ToDecimal(RandomNumber(9));
                            item.IndicaAlterado = true;

                        }
                    }

                }
                catch (Exception ex)
                {
                    return false;
                }

                Thread.Sleep(TimeSpan.FromMilliseconds(50));

            }
            return true;
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string RandomNumber(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        #region Commands
        #region Novo
        public NovoCommand Novo { get; private set; } = new NovoCommand();

        public class NovoCommand : BaseCommand
        {
            public override bool CanExecute(object parameter)
            {
                return parameter is MainWindowModel;
            }

            public override void Execute(object parameter)
            {
                var viewModel = (MainWindowViewModel)parameter;
                var NewConta = new MainWindowModel();
                long maxId = 0;
                if (viewModel.Orders.Any())
                {
                    maxId = viewModel.Orders.Max(f => f.Conta);
                }
                NewConta.Conta = maxId + 1;

            }
        }
        #endregion

        public IniciarCommand Iniciar { get; private set; } = new IniciarCommand();

        public class IniciarCommand : BaseCommand
        {
            public override bool CanExecute(object parameter)
            {
                return parameter is MainWindowViewModel;
            }

            public override void Execute(object parameter)
            {
                var viewModel = (MainWindowViewModel)parameter;
                viewModel.Stop = false;
                viewModel.startThreadXP();

            }

        }


        public PararCommand Parar { get; private set; } = new PararCommand();

        public class PararCommand : BaseCommand
        {
            public override bool CanExecute(object parameter)
            {
                return parameter is MainWindowViewModel;
            }

            public override void Execute(object parameter)
            {
                var viewModel = (MainWindowViewModel)parameter;

                viewModel.Stop = true; ;

            }

        }


        #endregion
    }
}


