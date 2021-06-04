using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine.Entity
{
    public interface IOrder
    {
        string Title { get; }
        PurchaseMode PurchaseMode { get; }
        Category Category { get; }
    }

    public interface IMemberShip
    {
        string UserId { get; }
        MembershipType MembershipType { get; }

    }

    public enum MembershipType
    {
        New,
        Upgrade
    }

    public enum PurchaseMode
    {
        Online,
        Physical
    }
    public enum Category
    {
        Book,
        Video,

    }

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
