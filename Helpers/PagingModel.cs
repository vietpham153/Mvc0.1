﻿namespace App.Helpers
{
    public class PagingModel
    {
            public int currentPages { get; set; }
            public int countPages { get; set; }
            public Func<int?, string> generateUrl { get; set; }

    }

}
