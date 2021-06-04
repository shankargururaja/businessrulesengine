using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine
{
    interface IOrder
    {
        string Title { get;}
        PurchaseMode PurchaseMode { get; }
        Category Category { get;}
    }

    interface IMemberShip
    {
        string UserId { get; }
        MembershipType MembershipType { get; }

    }

    enum MembershipType
    {
        New,
        Upgrade
    }

    enum PurchaseMode
    {
        Online,
        Physical
    }
    enum Category
    {
        Book,
        Video,

    }

    class NewMemberShip : IMemberShip
    {
        public string UserId { get; }

        public MembershipType MembershipType { get; }

        public NewMemberShip(string userId, MembershipType type)
        {
            MembershipType = type;
            UserId = userId;
        }
    }

    class Book : IOrder
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

    class Video : IOrder
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
