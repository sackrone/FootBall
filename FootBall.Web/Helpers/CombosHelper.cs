using FootBall.Web.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace FootBall.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetComboClubs()
        {
            List<SelectListItem> list = _context.Clubs.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = $"{c.Id}"
            }).OrderBy(c => c.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a Club...]",
                Value = "0"
            });

            return list;
        }
    }
}
