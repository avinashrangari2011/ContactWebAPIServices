using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContactWebAPIServices.Models
{
    /// <summary>
    /// Contact - This class is mapped with table TRAN_CONTACT and contains properties to map columns.
    /// </summary>
    [Table("TRAN_CONTACT")]
    public class ContactTableModel
    {
        [Key]
        public int CONTACT_ID { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string EMAIL { get; set; }
        public string PHONE { get; set; }
        public int STATUS_ID { get; set; }
    }

    /// <summary>
    /// Contact - This class contains properties to bind on view.
    /// </summary>
    public class ContactViewModel
    {
        #region Model properties

        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int StatusID { get; set; }
        public string StatusDesc { get; set; }
        public List<SYSCodeViewModel> StatusList { get; set; }
        
        #endregion Model properties
    }

    /// <summary> 
    /// Contact - This class has static function to provide contact related sevices like select,update, delete etc.
    /// </summary>
    public static class ContactServices
    {
        #region Static Methods
       
        /// <summary> Contact - This method id used to get all contact list.</summary>
        /// <returns>Contact list</returns>
        public static List<ContactViewModel> GetContacts()
        {
            using (MyDBContext lbusCon = new MyDBContext())
            {
                var lclbContact = (from c in lbusCon.idtbContactTableModel
                                   join s in lbusCon.idtbStatusTableModel
                                   on c.STATUS_ID equals s.ID
                                   select new ContactViewModel
                                   {
                                       ContactID = c.CONTACT_ID,
                                       FirstName = c.FIRST_NAME,
                                       LastName = c.LAST_NAME,
                                       Email = c.EMAIL,
                                       Phone = c.PHONE,
                                       StatusID = c.STATUS_ID,
                                       StatusDesc = s.DESCREPTION
                                   }).ToList();

                return lclbContact.ToList();
            }
        }

        /// <summary> Contact - This method is used to get contact by contact id.</summary>
        /// <param name="id">Contact ID</param>
        /// <returns>Contact model</returns>
        public static ContactViewModel GetContact(int aintContactID)
        {
            using (MyDBContext lbusCon = new MyDBContext())
            {
                var lbusContact = (from c in lbusCon.idtbContactTableModel
                                   join s in lbusCon.idtbStatusTableModel
                                   on c.STATUS_ID equals s.ID
                                   where c.CONTACT_ID == aintContactID
                                   select new ContactViewModel
                                    {
                                        ContactID = c.CONTACT_ID,
                                        FirstName = c.FIRST_NAME,
                                        LastName = c.LAST_NAME,
                                        Email = c.EMAIL,
                                        Phone = c.PHONE,
                                        StatusID = c.STATUS_ID,
                                        StatusDesc = s.DESCREPTION
                                    }).FirstOrDefault();
                if (lbusContact != null)
                    lbusContact.StatusList = (from s in lbusCon.idtbStatusTableModel
                                              //where s.ID == lbusContact.StatusID
                                              select new SYSCodeViewModel
                                              {
                                                  ID = s.ID,
                                                  Descreption = s.DESCREPTION,
                                                  MetaData = s.META_DATA
                                              }).ToList();
                return lbusContact;
            }
        }

        /// <summary> Contact - This method is used to update the contact.</summary>
        /// <param name="abusContact">Contact model</param>
        /// <returns>Returns true if record updated else false</returns>
        public static bool UpdateContact(ContactViewModel abusContact)
        {
            bool lblnIsSuccess;
            using (var lbusContext = new MyDBContext())
            {
                var lbusContact = lbusContext.idtbContactTableModel.Where(c => c.CONTACT_ID == abusContact.ContactID).FirstOrDefault();

                if (lbusContact != null)
                {
                    lbusContact.FIRST_NAME = abusContact.FirstName;
                    lbusContact.LAST_NAME = abusContact.LastName;
                    lbusContact.EMAIL = abusContact.Email;
                    lbusContact.PHONE = abusContact.Phone;
                    lbusContact.STATUS_ID = abusContact.StatusID;

                    lbusContext.SaveChanges();
                    lblnIsSuccess = true;
                }
                else
                    lblnIsSuccess = false;
            }
            return lblnIsSuccess;
        }

        /// <summary> Contact - This method is used to create/add new contact to databse.</summary>
        /// <param name="abusContact">Contatct model</param>
        /// <returns>Return true if contact added else false</returns>
        public static bool AddContact(ContactViewModel abusContact)
        {
            bool lblnIsSuccess;
            using (var lbusContext = new MyDBContext())
            {
                lbusContext.idtbContactTableModel.Add(new ContactTableModel()
                {
                    CONTACT_ID = abusContact.ContactID,
                    FIRST_NAME = abusContact.FirstName,
                    LAST_NAME = abusContact.LastName,
                    EMAIL = abusContact.Email,
                    PHONE = abusContact.Phone,
                    STATUS_ID = abusContact.StatusID
                });

                return lblnIsSuccess = (lbusContext.SaveChanges() > 0);
            }
        }

        /// <summary> Contact - This method is used to delete contact from databse.</summary>
        /// <param name="aintContact">Contatct id</param>
        /// <returns>Return true if contact deleted else false</returns>
        public static bool DeleteContact(int aintContact)
        {
            bool lblnIsSuccess;
            using (var lbusContext = new MyDBContext())
            {
                if (lbusContext.idtbContactTableModel.Any(c => c.CONTACT_ID == aintContact))
                {
                    lbusContext.idtbContactTableModel.
                       Remove(lbusContext.idtbContactTableModel.
                           FirstOrDefault(c => c.CONTACT_ID == aintContact));

                    return lblnIsSuccess = (lbusContext.SaveChanges() > 0);
                }
                else
                    return false;
            }
        }

        #endregion Static Methods
    }

}