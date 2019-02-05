using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{
    public class PropertySettings
    {
        private List<int> _favoriteItems = new List<int>();

        public int PropertyId { get; set; }

        public List<int> FavoriteItems
        {
            get { return _favoriteItems; }
            set { _favoriteItems = value; }
        }

    }
}
