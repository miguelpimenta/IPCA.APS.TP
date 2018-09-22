using GesNautico.Shared.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesNautico.DAL.LiteDB
{
    public interface ILitedbDAL : IDisposable
    {

        int GetNextNumAtleta(string table);
        //? TODO
        bool CheckNumber(string table, int number);
        bool InsertAtleta(Atleta atleta);
        bool UpdateAtleta(Atleta atleta);
        Atleta ReadAtleta(Guid idAtleta);        
        ObservableCollection<Atleta> ListAtletas(string search, string empty1, string empty2, string empty3, bool active);
        
        bool InsertProva(Prova prova);
        bool UpdateProva(Prova prova);
        Prova ReadProva(Guid idProva);
        ObservableCollection<Prova> ListProvas(string search, string empty1, string empty2, string empty3);

        bool InsertPremio(Premio premio);
        bool UpdatePremio(Premio premio);
        Premio ReadPremio(Guid idPremio);
        ObservableCollection<Premio> ListPremios(string search, string empty1, string empty2, string empty3);

        bool InsertSocio(Socio socio);
        bool UpdateSocio(Socio socio);
        Socio ReadSocios(Guid idSocio);
        ObservableCollection<Socio> ListSocios(string search, string empty1, string empty2, string empty3);

        bool InsertQuota(Quota quota);
        bool UpdateQuota(Quota quota);
        Quota ReadQuota(Guid idQuota);
        ObservableCollection<Quota> ListQuotas(string search, string empty1, string empty2, string empty3);

        bool InsertBsonDocument(BsonDocument bsonDocument, string table);

    }
}
