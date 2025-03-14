using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALMADINA.Entity
{
    public enum Status
    {
        Paid,
        Partial,
        Unpaid
    }

    public class FeesRegister
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public string StudentName { get; set; }
        public string FatehrsName { get; set; }
        public string MotehrsName { get; set; }
        public int? LevelOrClassId { get; set; }
        public int? SectionId { get; set; }
        public string RollNo { get; set; }
        public int? FeeTypeId { get; set; }

        // Amount Information (Currency:BDT)
        public decimal FeeAmount { get; set; }
        public decimal FeeAlreadyRecived { get; set; }
        public decimal DueAmount { get; set; }
        public decimal PaidAmount { get; set; }

        // Payment System for Cash
        public decimal Cash { get; set; }

        // Payment System for bKash
        public decimal BKash { get; set; }

        // Payment System for Nagad
        public decimal Nagad { get; set; }

        // Payment System for Pay & Paid
        public decimal PayandPaid { get; set; }
       
        public string Reference { get; set; }


        //Database info
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public Status Status { get; set; }
        public int? UserId { get; set; }

        public virtual FeeType FeeType { get; set; }
        public virtual Student Student { get; set; }
        public virtual LevelOrClass LevelOrClass { get; set; }
        public virtual Section Section { get; set; }
        public virtual User User { get; set; }
    }
}