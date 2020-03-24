﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace DatabaseConnector.DAO.Entity
{
    [Table("Chemical")]
    public class Chemical
    {
        [JsonPropertyName("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChemicalId { get; set; }
        [JsonPropertyName("name")]
        [Required,MaxLength(64)]
        public string Name { get; set; }
        //所在实验室
        [JsonPropertyName("labId")]
        [Required]
        public int LabId { get; set; }
        [JsonPropertyName("labName")]
        public string LabName { get; set; }
        [JsonPropertyName("amount")]
        [Required]
        public int Amount { get; set; }
        [JsonPropertyName("state")]
        public ChemicalState State { get; set; } = ChemicalState.None;
        
    }
    public enum ChemicalState { None = 0, Lab, InUse, Obsoleted }
}
