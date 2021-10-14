﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherApi.Data.Dtos
{
    public class FlashCardSetDto
    {        
        public int? Id { get; set; }
        public string Title { get; set; }


        public FlashCardSetDto FlashCardSupersetDto { get; set; }
    }
}
