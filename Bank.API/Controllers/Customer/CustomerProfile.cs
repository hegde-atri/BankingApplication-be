using AutoMapper;
using Bank.API.Models;
using Bank.Data.Entities;

namespace Bank.API.Controllers.Customer
{
  public class CustomerProfile:Profile
  {
    public CustomerProfile()
    {
      // When a EntityModel object is being mapped to a Entity object which will be sent a database, we do not map any PK's or FK's.
      // This is to avoid accidentally changing these values.
      // That is what opt ignore does. 
      // Bank.Data/Entities/Account.cs is an entity
      // BankAPI/Models/AccountModel.cs is a entityModel
      
      this.CreateMap<Data.Entities.Customer, CustomerModel>()
              .ReverseMap()
              .ForMember(a => a.Accounts, opt => opt.Ignore())
              .ForMember(a => a.Payees, opt => opt.Ignore())
              .ForMember(a => a.Addresses, opt => opt.Ignore())
              .ForMember(a => a.Notifications, opt => opt.Ignore());
      this.CreateMap<Account, AccountModel>()
        .ReverseMap();

      
      this.CreateMap<Address, AddressModel>()
        .ReverseMap();
        // .ForMember(a => a.AddressId, opt => opt.Ignore());
        // .ForMember(a => a.CustomerId, opt => opt.Ignore());

        
        this.CreateMap<Transaction, TransactionModel>()
          .ReverseMap()
          .ForMember(a => a.TransactionId, opt => opt.Ignore());


        this.CreateMap<Notification, NotificationModel>()
          .ReverseMap()
          .ForMember(a => a.NotificationId, opt => opt.Ignore());


        this.CreateMap<Payee, PayeeModel>()
          .ReverseMap();
        // .ForMember(a => a.PayeeId, opt => opt.Ignore())
        // .ForMember(a => a.CustomerId, opt => opt.Ignore());

        
      



    }
  }
}