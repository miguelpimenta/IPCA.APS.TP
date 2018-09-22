using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GesNautico.Shared.Models;
using GesNautico.Shared.Extensions;
using LiteDB;
using System.Data;
using System.Collections.ObjectModel;

namespace GesNautico.DAL.LiteDB
{
    public class LitedbDAL : ILitedbDAL
    {

        #region Ensure Index
        private void IndexLitedb(LiteCollection<Atleta> atletas)
        {            
            atletas.EnsureIndex(x => x.Id);            
            atletas.EnsureIndex(x => x.Nome);            
        }

        private void IndexLitedb(LiteCollection<Prova> provas)
        {
            provas.EnsureIndex(x => x.IdProva);            
        }

        private void IndexLitedb(LiteCollection<Premio> premios)
        {
            premios.EnsureIndex(x => x.IdPremio);
        }

        private void IndexLitedb(LiteCollection<Socio> socios)
        {
            socios.EnsureIndex(x => x.Id);
        }

        private void IndexLitedb(LiteCollection<Quota> quotas)
        {
            quotas.EnsureIndex(x => x.IdQuota);
        }

        private void IndexLitedb(LiteCollection<BsonDocument> collection)
        {            
            collection.EnsureIndex(x => x.IsObjectId);            
            collection.EnsureIndex(x => x.IsGuid);
        }
        #endregion


        #region Atletas...

        #region Get Next Num Atleta
        public int GetNextNumAtleta(string table)
        {
            try
            {
                var db = new LiteDatabase(LitedbConn.ConnString());

                var atletas = db.GetCollection<Atleta>("Atletas");

                var results = atletas.FindAll()
                    .Select(x => new { x.NumAtleta })
                    .OrderByDescending(x => x.NumAtleta);
                if (results.FirstOrDefault() == null)
                {
                    return 1;
                }
                else
                {
                    return int.Parse(results.First().NumAtleta.ToString()) + 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Check Number
        public bool CheckNumber(string table, int number)
        {
            try
            {
                var db = new LiteDatabase(LitedbConn.ConnString());

                var atletas = db.GetCollection<Atleta>("Atletas");

                var results = atletas.FindAll().Where(x => x.NumAtleta == number);

                if (results.FirstOrDefault() == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Insert Atleta
        public bool InsertAtleta(Atleta atleta)
        {
            var db = new LiteDatabase(LitedbConn.ConnString());

            var atletas = db.GetCollection<Atleta>("Atletas");

            try
            {
                atletas.Insert(atleta);
                IndexLitedb(atletas);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Read Atleta
        public Atleta ReadAtleta(Guid idAtleta)
        {
            var db = new LiteDatabase(LitedbConn.ConnString());

            var atletas = db.GetCollection<Atleta>("Atletas");

            try
            {                
                var result = atletas.FindById(idAtleta);
                return result;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region Update Atleta
        public bool UpdateAtleta(Atleta atleta)
        {
            var db = new LiteDatabase(LitedbConn.ConnString());

            var atletas = db.GetCollection<Atleta>("Atletas");

            try
            {
                var result = atletas.Update(atleta);
                IndexLitedb(atletas);
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }
        #endregion

        #region List Atletas

        //public DataTable ListAtletas(string search, string empty1, string empty2, string empty3, bool active)
        //{
        //    var db = new LiteDatabase(LitedbConn.ConnString());

        //    var atletas = db.GetCollection<Atleta>("Atletas");

        //    if (!string.IsNullOrEmpty(search))
        //    {
        //        try
        //        {
        //            var results = atletas.FindAll().Where(x => x.Activo == active)
        //                .Select(x => new { x.Id, x.NumAtleta, x.Nome, x.Email, x.Escalao, x.Telef, x.Tlm, x.DataNasc })
        //                .Where(x => x.Nome.ToUpper().Contains(search.ToUpper()))
        //                .OrderBy(x => x.NumAtleta);
        //            return results.ToDataTable();
        //        }
        //        catch (Exception ex)
        //        {
        //            return null;
        //        }
        //    }
        //    else
        //    {
        //        try
        //        {
        //            var results = atletas.FindAll().Where(x => x.Activo == active)
        //                .Select(x => new { x.Id, x.NumAtleta, x.Nome, x.Email, x.Escalao, x.Telef, x.Tlm, x.DataNasc })
        //                .OrderBy(x => x.NumAtleta);
        //            return results.ToDataTable();
        //        }
        //        catch (Exception ex)
        //        {
        //            return null;
        //        }
        //    }
        //}

        public ObservableCollection<Atleta> ListAtletas(string search, string escalao, string empty2, string empty3, bool active)
        {
            //ObservableCollection<Atleta> atletasOC;

            var db = new LiteDatabase(LitedbConn.ConnString());

            var atletas = db.GetCollection<Atleta>("Atletas");

            try
            {
                var results = atletas.FindAll().Where(x => x.Activo == active)
                    .Where(x => x.Nome.ToUpper().Contains(search.ToUpper()))
                    .Where(x => x.Escalao.ToUpper().Contains(escalao.ToUpper()))
                    .OrderBy(x => x.NumAtleta);
                return results.AsEnumerable().ToObservableCollection<Atleta>();
            }
            catch (Exception ex)
            {
                throw ex;
            }


            //if (!string.IsNullOrEmpty(search))
            //{
            //    try
            //    {
            //        var results = atletas.FindAll().Where(x => x.Activo == active)
            //            .Where(x => x.Nome.ToUpper().Contains(search.ToUpper()))
            //            .Where(x => x.Escalao.ToUpper().Contains(escalao.ToUpper()));


            //        //.Select(x => new { x.Id, x.NumAtleta, x.Nome, x.Email, x.Escalao })
            //        //.Where(x => x.Nome.ToUpper().Contains(search.ToUpper()))
            //        //.OrderBy(x => x.NumAtleta);
            //        return results.AsEnumerable().ToObservableCollection<Atleta>();
            //    }
            //    catch (Exception ex)
            //    {
            //        return null;
            //    }
            //}
            //else
            //{
            //    try
            //    {
            //        var results = atletas.FindAll().Where(x => x.Activo == active)
            //            .Where(x => x.Escalao.ToUpper().Contains(escalao.ToUpper()));

            //        //.Select(x => new { x.Id, x.NumAtleta, x.Nome, x.Email, x.Escalao })
            //        //.OrderBy(x => x.NumAtleta);
            //        //return results.ToDataTable();
            //        return results.AsEnumerable().ToObservableCollection<Atleta>();
            //    }
            //    catch (Exception ex)
            //    {
            //        return null;
            //    }
            //}
        }
        #endregion

        #endregion

        #region Provas...
        bool ILitedbDAL.InsertProva(Prova prova)
        {
            var db = new LiteDatabase(LitedbConn.ConnString());

            var provas = db.GetCollection<Prova>("Provas");

            try
            {
                provas.Insert(prova);
                IndexLitedb(provas);
                return true;
            }
            catch
            {
                return false;
            }
        }

        bool ILitedbDAL.UpdateProva(Prova prova)
        {
            var db = new LiteDatabase(LitedbConn.ConnString());

            var provas = db.GetCollection<Prova>("Provas");

            try
            {
                provas.Update(prova);
                IndexLitedb(provas);
                return true;
            }
            catch
            {
                return false;
            }
        }

        Prova ILitedbDAL.ReadProva(Guid idProva)
        {
            var db = new LiteDatabase(LitedbConn.ConnString());

            var provas = db.GetCollection<Prova>("Provas");

            try
            {
                var result = provas.FindById(idProva);
                return result;
            }
            catch
            {
                return null;
            }
        }

        ObservableCollection<Prova> ILitedbDAL.ListProvas(string search, string empty1, string empty2, string empty3)
        {
            var db = new LiteDatabase(LitedbConn.ConnString());

            var provas = db.GetCollection<Prova>("Provas");

            try
            {
                var results = provas.FindAll();
                return results.AsEnumerable().ToObservableCollection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Premios...
        bool ILitedbDAL.InsertPremio(Premio premio)
        {
            var db = new LiteDatabase(LitedbConn.ConnString());

            var premios = db.GetCollection<Premio>("Premios");

            try
            {
                premios.Insert(premio);
                IndexLitedb(premios);
                return true;
            }
            catch
            {
                return false;
            }
        }

        bool ILitedbDAL.UpdatePremio(Premio premio)
        {
            var db = new LiteDatabase(LitedbConn.ConnString());

            var premios = db.GetCollection<Premio>("Premios");

            try
            {
                premios.Update(premio);
                IndexLitedb(premios);
                return true;
            }
            catch
            {
                return false;
            }
        }

        Premio ILitedbDAL.ReadPremio(Guid idPremio)
        {
            var db = new LiteDatabase(LitedbConn.ConnString());

            var premios = db.GetCollection<Premio>("Premios");

            try
            {
                var result = premios.FindById(idPremio);
                return result;
            }
            catch
            {
                return null;
            }
        }

        ObservableCollection<Premio> ILitedbDAL.ListPremios(string search, string empty1, string empty2, string empty3)
        {
            var db = new LiteDatabase(LitedbConn.ConnString());

            var premios = db.GetCollection<Premio>("Premios");

            try
            {
                var results = premios.FindAll();
                return results.AsEnumerable().ToObservableCollection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Socios...
        bool ILitedbDAL.InsertSocio(Socio socio)
        {
            var db = new LiteDatabase(LitedbConn.ConnString());

            var socios = db.GetCollection<Socio>("Socios");

            try
            {
                socios.Insert(socio);
                IndexLitedb(socios);
                return true;
            }
            catch
            {
                return false;
            }
        }

        bool ILitedbDAL.UpdateSocio(Socio socio)
        {
            var db = new LiteDatabase(LitedbConn.ConnString());

            var socios = db.GetCollection<Socio>("Socios");

            try
            {
                socios.Update(socio);
                IndexLitedb(socios);
                return true;
            }
            catch
            {
                return false;
            }
        }

        Socio ILitedbDAL.ReadSocios(Guid idSocio)
        {
            var db = new LiteDatabase(LitedbConn.ConnString());

            var socios = db.GetCollection<Socio>("Socios");

            try
            {
                var result = socios.FindById(idSocio);
                return result;
            }
            catch
            {
                return null;
            }
        }

        ObservableCollection<Socio> ILitedbDAL.ListSocios(string search, string empty1, string empty2, string empty3)
        {
            var db = new LiteDatabase(LitedbConn.ConnString());

            var socios = db.GetCollection<Socio>("Socios");

            try
            {
                var results = socios.FindAll();
                return results.AsEnumerable().ToObservableCollection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Quota
        bool ILitedbDAL.InsertQuota(Quota quota)
        {
            var db = new LiteDatabase(LitedbConn.ConnString());

            var quotas = db.GetCollection<Quota>("Quotas");

            try
            {
                quotas.Insert(quota);
                IndexLitedb(quotas);
                return true;
            }
            catch
            {
                return false;
            }
        }

        bool ILitedbDAL.UpdateQuota(Quota quota)
        {
            var db = new LiteDatabase(LitedbConn.ConnString());

            var quotas = db.GetCollection<Quota>("Quotas");

            try
            {
                quotas.Update(quota);
                IndexLitedb(quotas);
                return true;
            }
            catch
            {
                return false;
            }
        }

        Quota ILitedbDAL.ReadQuota(Guid idQuota)
        {
            var db = new LiteDatabase(LitedbConn.ConnString());

            var quotas = db.GetCollection<Quota>("Quotas");

            try
            {
                var result = quotas.FindById(idQuota);
                return result;
            }
            catch
            {
                return null;
            }
        }

        ObservableCollection<Quota> ILitedbDAL.ListQuotas(string search, string empty1, string empty2, string empty3)
        {
            var db = new LiteDatabase(LitedbConn.ConnString());

            var quotas = db.GetCollection<Quota>("Quotas");

            try
            {
                var results = quotas.FindAll();
                return results.AsEnumerable().ToObservableCollection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        bool ILitedbDAL.InsertBsonDocument(BsonDocument bsonDocument, string table)
        {
            var db = new LiteDatabase(LitedbConn.ConnString());

            var collection = db.GetCollection(table);

            try
            {
                collection.Insert(bsonDocument);
                IndexLitedb(collection);
                return true;
            }
            catch
            {
                return false;
            }
        }


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~LitedbDAL() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
