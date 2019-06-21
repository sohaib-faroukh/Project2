﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
    public class Survey
    {
        [Key]
        public int Id { get; set; }

        // word carry survey uniqe name
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string Name { get; set; }

        // sentence represent what this survey for and what's
        [MaxLength(100)]
        public string Description { get; set; }


        // creation survey time
        public DateTime creationDate { get; set; }

        // how many months this survey will stil valid
        public int ValidiatyMonthlyPeriod { get; set; }


        // survey avtive period 
        // FromDate = null if the survey status is inactive
        // toDate = null if ToDate = null
        // toDate = null that means the survey always active until dynamicly deactivate it 

        public DateTime? FromDate
        {
            get { return FromDate; }
            set
            {
                if (this.Status != null && this.Status.Trim().ToLower() == "inactive")
                {
                    this.FromDate = null;
                }
                else
                {
                    this.FromDate = this.FromDate;
                }
            }
        }
        public DateTime? ToDate
        {

            get { return ToDate; }
            set
            {
                if (this.ToDate != null)
                {


                    if (this.FromDate == null)
                    {
                        this.ToDate = null;
                    }
                    else
                    {
                        this.ToDate = this.ToDate;
                    }
                }
            }
        }


        // survey current status "active,inactive,pendding,..."
        public string Status
        {
            get { return Status; }
            set
            {
                if (this.Status != null)
                {
                    this.Status = this.Status.Trim().ToUpper();
                }
                else
                {
                    throw new Exception("Status can't be null");
                }
            }
        }


        // User who have created the survey forign key
        public int CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public virtual User Creator { get; set; }


        // survey has one or several questions
        public virtual ICollection<SurveyQuestion> Questions { get; set; }



        public Survey() { }
        ~Survey() { }
    }
}
