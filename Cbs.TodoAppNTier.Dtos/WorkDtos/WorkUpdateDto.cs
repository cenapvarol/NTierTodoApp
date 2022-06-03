﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cbs.TodoAppNTier.Dtos.WorkDtos
{
    public class WorkUpdateDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "Id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Definition is required ")]
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
