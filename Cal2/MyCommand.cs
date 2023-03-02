using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cal2;
using System.Windows.Input;

namespace Cal2
{
    abstract class Command : ICommand
    {
        protected ViewModel _viewModel;

        public Command(ViewModel vm)
        {
            _viewModel = vm;
        }

        public event EventHandler CanExecuteChanged;
        public abstract bool CanExecute(object arg);
        public abstract void Execute(object arg);
    }

    class AddCommand:Command
    {
        public AddCommand(ViewModel vm) : base(vm)
        {

        }

        public override bool CanExecute(object arg)
        {
            return true;
        }

        public override void Execute(object arg)
        {
            _viewModel.Result = _viewModel.FirstNumber + _viewModel.SecondNumber;
            _viewModel.Sign = "+";
        }
    }

    class SubCommand : Command
    {
        public SubCommand(ViewModel vm) : base(vm)
        {

        }

        public override bool CanExecute(object arg)
        {
            return true;
        }

        public override void Execute(object arg)
        {
            _viewModel.Result = _viewModel.FirstNumber - _viewModel.SecondNumber;
        }
    }
    class MulCommand : Command
    {
        public MulCommand(ViewModel vm) : base(vm)
        {

        }

        public override bool CanExecute(object arg)
        {
            return true;
        }

        public override void Execute(object arg)
        {
            _viewModel.Result = _viewModel.FirstNumber * _viewModel.SecondNumber;
        }
    }
    class DivCommand : Command
    {
        public DivCommand(ViewModel vm) : base(vm)
        {

        }

        public override bool CanExecute(object arg)
        {
            return true;
        }

        public override void Execute(object arg)
        {
            if(_viewModel.SecondNumber != 0)
            {
                _viewModel.Result = _viewModel.FirstNumber / _viewModel.SecondNumber;
            }
        }
    }
}
