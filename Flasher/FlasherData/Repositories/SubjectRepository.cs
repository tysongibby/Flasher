using FlasherData.Repositories.Interfaces;
using FlasherData.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlasherData.Context;

namespace FlasherData.Repositories
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(FlasherContext context) : base(context) 
        {
        }
        public FlasherContext FlasherContext
        {
            get
            {
                return _context as FlasherContext;
            }
        }

        //public override int Update(Subject subjectUpdate)
        //{
        //    try
        //    {
        //        if (subjectUpdate == null)
        //        {
        //            throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
        //        }
        //        //TODO: add update entity to BaseRepository.cs if possible                
        //        Subject subjectToUpdate = FlasherContext.Subjects.Find(subjectUpdate.Id);
        //        if (subjectToUpdate != null)
        //        {
        //            subjectToUpdate.Name = subjectUpdate.Name;
        //            FlasherContext.SaveChangesAsync();
        //        }
        //        return subjectToUpdate.Id;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception($"Flashcard could not be updated: {e.Message}");
        //    }


        //}
    }
}
