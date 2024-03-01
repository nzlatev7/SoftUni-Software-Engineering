using Command.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class ProductCommand : ICommand
    {
        private readonly Product _product;
        private readonly PriceAction _action;
        private readonly decimal _amount;

        public ProductCommand(
            Product product, 
            PriceAction action,
            decimal amount)
        {
            _product = product;
            _action = action;
            _amount = amount;
        }

        public void Execute()
        {
            if (_action == PriceAction.Increase)
            {
                _product.IncreasePrice(_amount);
            }
            else
            {
                _product.DecreasePrice(_amount);
            }
        }
    }
}
