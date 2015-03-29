using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicketingManagement.Model
{
    [Serializable]
    public class TicketModel
    {
        public  TicketModel() { }

        private int id;

        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        private string title;

        [Required(ErrorMessage = "Title must be specified")]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        [Required(ErrorMessage = "Description must be specified")]
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        
        //[Required(ErrorMessage = "Username must be specified")]
        private string username;
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        private string location;
        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        private string steps;
        public string Steps
        {
            get { return steps; }
            set { steps = value; }
        }

        private string actions;
        public string Actions
        {
            get { return actions; }
            set { actions = value; }
        }

        private bool status;
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        private string assigned;
        public string Assigned
        {
            get { return assigned; }
            set { assigned = value; }
        }
        private DateTime created;
        public DateTime Created
        {
            get { return created; }
            set { created = value; }
        }
    }
}