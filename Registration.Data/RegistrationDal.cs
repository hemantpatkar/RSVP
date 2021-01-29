using Registration.Data.Master;
using Registration.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Registration.Data
{
    public class RegistrationDal : IRegistrationDal
    {
        private readonly IMasterDatabaseUtils _db;
        public RegistrationDal(IMasterDatabaseUtils db)
        {
            _db = db;
        }
        public async Task<bool> AddRegistration(Register Request)
        {
            try
            {
                var Parameters = new Dictionary<string, string>();

                Parameters.Add("Name", Request.Name);
                Parameters.Add("DOB", Convert.ToString(Request.DOB));
                Parameters.Add("Address", Request.Address);
                Parameters.Add("Age", Convert.ToString(Request.Age));
                Parameters.Add("Profession", Convert.ToString((int)Request.Profession));
                Parameters.Add("NoOfGuest", Convert.ToString(Request.NoOfGuest));
                Parameters.Add("Locality", Request.Locality);

                try
                {
                    await _db.ExecuteDataSetAsync("AddRegistration", CommandType.StoredProcedure, Parameters);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteRegistration(int ID)
        {
            var Parameters = new Dictionary<string, string>();
            Parameters.Add("ID", Convert.ToString(ID));

            List<Register> list = new List<Register>();

            try
            {
                await _db.ExecuteDataSetAsync("DeleteRegistration", CommandType.StoredProcedure, Parameters);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<Register> GetRegistrationDetails(int ID)
        {
            try
            {
                var Parameters = new Dictionary<string, string>();
                Parameters.Add("ID", Convert.ToString(ID));
                var entity = new Register();
                var reader = await _db.ExecuteDataReaderAsync("GetRegistration", CommandType.StoredProcedure, Parameters);
                using (reader)
                {
                    while (reader.Read())
                    {

                        entity.ID = reader["ID"] as Int32? ?? default(Int32);
                        entity.Name = reader["Name"] as string;
                        entity.Address = reader["Address"] as string;
                        entity.Locality = reader["Locality"] as string;
                        int e = Convert.ToInt32(reader["Profession"]);
                        Profession myenum = (Profession)e;
                        entity.Profession = myenum;
                        entity.DOB = Convert.ToDateTime(reader["DOB"]);
                        entity.Age = Convert.ToInt32(reader["Age"]);
                        entity.NoOfGuest = Convert.ToInt32(reader["NoOfGuest"]);

                    }
                    return entity;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Register>> GetRegistrationList(string Search)
        {
            try
            {
                var Parameters = new Dictionary<string, string>();
                Parameters.Add("search", Search);
                List<Register> list = new List<Register>();
                var reader = await _db.ExecuteDataReaderAsync("GetRegistrations", CommandType.StoredProcedure, Parameters);
                using (reader)
                {
                    while (reader.Read())
                    {
                        var entity = new Register();
                        entity.ID = reader["ID"] as Int32? ?? default(Int32);
                        entity.Name = reader["Name"] as string;
                        entity.Address = reader["Address"] as string;
                        entity.Locality = reader["Locality"] as string;
                        int e = Convert.ToInt32(reader["Profession"]);
                        Profession myenum = (Profession)e;
                        entity.Profession = myenum;
                        entity.DOB = Convert.ToDateTime(reader["DOB"]);
                        entity.Age = Convert.ToInt32(reader["Age"]);
                        entity.NoOfGuest = Convert.ToInt32(reader["NoOfGuest"]);

                        list.Add(entity);
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<bool> UpdateRegistration(Register Request)
        {
            try
            {
                var Parameters = new Dictionary<string, string>();
                Parameters.Add("ID", Convert.ToString(Request.ID));
                Parameters.Add("Name", Request.Name);
                Parameters.Add("DOB", Convert.ToString(Request.DOB));
                Parameters.Add("Address", Request.Address);
                Parameters.Add("Age", Convert.ToString(Request.Age));
                Parameters.Add("Profession", Convert.ToString((int)Request.Profession));
                Parameters.Add("NoOfGuest", Convert.ToString(Request.NoOfGuest));
                Parameters.Add("Locality", Request.Locality);

                try
                {
                    await _db.ExecuteDataSetAsync("UpdateRegistration", CommandType.StoredProcedure, Parameters);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
