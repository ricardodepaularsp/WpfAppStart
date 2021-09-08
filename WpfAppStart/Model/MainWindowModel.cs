using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppStart
{
    public class MainWindowModel : BaseNotifyPropertyChanged
    {
        private DateTime _DataHora;
        public DateTime DataHora
        {
            get { return _DataHora; }
            set { SetProperty(ref _DataHora, value); }
        }

        private string _Assessor;
        public string Assessor
        {
            get { return _Assessor; }
            set { SetProperty(ref _Assessor, value); }
        }

        private long _Conta;
        public long Conta
        {
            get { return _Conta; }
            set { SetProperty(ref _Conta, value); }
        }

        private string _ativo;
        public string Ativo
        {
            get { return _ativo; }
            set { SetProperty(ref _ativo, value); }
        }

        private string _Tipo;
        public string Tipo
        {
            get { return _Tipo; }
            set { SetProperty(ref _Tipo, value); }
        }

        private int _Qtd;
        public int Qtd
        {
            get { return _Qtd; }
            set { SetProperty(ref _Qtd, value); }
        }

        private int _QtdAparente;
        public int QtdAparente
        {
            get { return _QtdAparente; }
            set { SetProperty(ref _QtdAparente, value); }
        }

        private int _QtdDisp;
        public int QtdDisp
        {
            get { return _QtdDisp; }
            set { SetProperty(ref _QtdDisp, value); }
        }

        private int _QtdCancel;
        public int QtdCancel
        {
            get { return _QtdCancel; }
            set { SetProperty(ref _QtdCancel, value); }
        }

        private int _QtdExec;
        public int QtdExec
        {
            get { return _QtdExec; }
            set { SetProperty(ref _QtdExec, value); }
        }
        private decimal _Valor;
        public decimal Valor
        {
            get { return _Valor; }
            set { SetProperty(ref _Valor, value); }
        }
        private decimal _ValorDisp;
        public decimal ValorDisp
        {
            get { return _ValorDisp; }
            set { SetProperty(ref _ValorDisp, value); }
        }


        private decimal _Objetivo;
        public decimal Objetivo
        {
            get { return _Objetivo; }
            set { SetProperty(ref _Objetivo, value); }
        }

        private decimal _ObjDisp;
        public decimal ObjDisp
        {
            get { return _ObjDisp; }
            set { SetProperty(ref _ObjDisp, value); }
        }

        private decimal _Reducao;
        public decimal Reducao
        {
            get { return _Reducao; }
            set { SetProperty(ref _Reducao, value); }
        }

        private bool _IndicaAlterado;
        public bool IndicaAlterado
        {
            get { return _IndicaAlterado; }
            set { SetProperty(ref _IndicaAlterado, value); }
        }
    }
}
