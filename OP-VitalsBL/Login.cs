using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DTO;

namespace OP_VitalsBL
{
    public class Login  // public tilføjet
    {
        private iOPVitalsDAL currentDal;
        private EmployeeDTO employee;

        public Login(iOPVitalsDAL currentDal)
        {
            this.currentDal = currentDal;
        }
        
        //public bool LoginMetode(int id, string kodeord)
        //{
        //    return currentDal.ValiderLogin(id,kodeord);
        //}

        ////Denne metoder benyttes til at finde ud af om vedkommende der logger ind er operationssygeplejerske.
        //public bool IsOPNurse()
        //{
        //    string profession = "OPSygeplejerske"; //
        //    bool result = false;
        //    if(string.Equals(profession,employee.Profession_)==true)
        //    {
        //        result = true;
        //    }
        //    return result;
        //}
    }
}
