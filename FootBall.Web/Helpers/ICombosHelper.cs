using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FootBall.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboClubs();

        IEnumerable<SelectListItem> GetComboTypeSession();
    }
}
