﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gig_website.Models
{
    public class UserNotification
    { 
        [Key]
        [Column(Order = 1) ]
        public string UserId { get;private set; }


        [Key]
        [Column(Order = 2)]
        public int NotificationId { get;private set; }

        public ApplicationUser User { get; private set; }

        public Notification Notification { get; private set;}

        public bool ISRead { get;private set;}

        protected  UserNotification()
        {

        }

        public UserNotification(ApplicationUser  user,Notification notification)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (notification == null)
                throw new ArgumentException("notification");

            User = user;
            Notification = notification;
        }
        public void Read()
        {
            ISRead = true; 
        }
    }
}