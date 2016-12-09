using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akokina.ViewModel
{
    public class MovementListItemViewModel
    {
        public string User { get; set; }
        public string Title { get; set; }
        public DateTime ValueDate { get; set; }
        public decimal Amount { get; set; }
        public bool IsCurrentUser { get; set; }

        public static MovementListItemViewModel Create(Model.Movement template)
        {
            var instance = new MovementListItemViewModel();

            instance.User = template.User.Initials;
            instance.Title = template.Title;
            instance.ValueDate = template.ValueDate;
            instance.Amount = template.Amount;
            instance.IsCurrentUser = (template.UserId == Helpers.Settings.UserId);

            return instance;
        }
    }
}
