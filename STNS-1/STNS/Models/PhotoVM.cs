using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STNS.Models
{
    public class PhotoVM
    {
        public int PhotoId { get; set; }

    }

    public class AlbumImageFile : File { }
    public class UserPhotoFile : File { }
}