using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine.Entity
{

    /// <summary>
    /// Order Interface for Items that would be ordered
    /// </summary>
    public interface IOrder
    {
        string Title { get; }
        PurchaseMode PurchaseMode { get; }
        Category Category { get; }
    }


    /// <summary>
    /// Interface definition for Membership processing
    /// </summary>
    public interface IMemberShip
    {
        string UserId { get; }
        MembershipType MembershipType { get; }

    }

    /// <summary>
    /// Membership type
    /// </summary>
    public enum MembershipType
    {
        New,
        Upgrade
    }

    /// <summary>
    /// Purchase Mode
    /// </summary>
    public enum PurchaseMode
    {
        Online,
        Physical
    }

    /// <summary>
    /// Order Category
    /// </summary>
    public enum Category
    {
        Book,
        Video,

    }

    /// <summary>
    /// Membership class
    /// </summary>
    public class NewMemberShip : IMemberShip
    {
        public string UserId { get; }

        public MembershipType MembershipType { get; }

        public NewMemberShip(string userId, MembershipType type)
        {
            MembershipType = type;
            UserId = userId;
        }
    }

    /// <summary>
    /// Book Class
    /// </summary>
    public class Book : IOrder
    {
        public string Title { get; }

        public PurchaseMode PurchaseMode { get; }

        public Category Category => Category.Book;

        public Book(string title, PurchaseMode mode)
        {
            Title = title;
            PurchaseMode = mode;
        }
    }

    /// <summary>
    /// Video class
    /// </summary>
    public class Video : IOrder
    {
        private string _title;
        private PurchaseMode _mode;
        public string Title => _title;

        public PurchaseMode PurchaseMode => _mode;

        public Category Category => Category.Video;

        public Video(string title, PurchaseMode mode)
        {
            _title = title;
            _mode = mode;
        }
    }
}
