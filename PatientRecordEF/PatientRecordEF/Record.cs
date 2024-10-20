using System;
using System.Collections.Generic;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Xml.Linq;

namespace PatientRecordEF
{
    public class PatientRecordService
    {
        public List<Patientrecord> GetAllPatientRecord()
        {
            // Use the correct DbContext class here
            using (MVCApiRecordEntities mVCApiRecordEntities = new MVCApiRecordEntities())
            {
                // Fetch all records from the Patientrecords table and map them to PatientRecord class
                return mVCApiRecordEntities.Patientrecords.ToList();
            }
        }

        public Patientrecord GetPatientRecordByID(string Id)
        {
            using (MVCApiRecordEntities mVCApiRecordEntities = new MVCApiRecordEntities())
            {
                return mVCApiRecordEntities.Patientrecords
                                         .FirstOrDefault(record => record.id.Equals(Id, StringComparison.OrdinalIgnoreCase)); // Convert Id to string

            }
        }

        public Patientrecord GetPatientRecordByName(string name)
        {
            using (MVCApiRecordEntities mVCApiRecordEntities = new MVCApiRecordEntities())
            {
                return mVCApiRecordEntities.Patientrecords
                    .FirstOrDefault(r => r.name.Equals(name, StringComparison.OrdinalIgnoreCase));
            }
        }

        public Patientrecord GetPatientRecordByBloodGroup(string bloodGroup)
        {
            using (MVCApiRecordEntities mVCApiRecordEntities = new MVCApiRecordEntities())
            {
                return mVCApiRecordEntities.Patientrecords
                    .FirstOrDefault(r => r.bloodType.Equals(bloodGroup, StringComparison.OrdinalIgnoreCase));
            }
        }

        public Patientrecord GetPatientAdmitDate(DateTime dateTime)
        {
            using (MVCApiRecordEntities mVCApiRecordEntities = new MVCApiRecordEntities())
            {
                return mVCApiRecordEntities.Patientrecords
                    .FirstOrDefault(r => r.dateOfAdmission == dateTime);

                //return mVCApiRecordEntities.Patientrecords
                //        .Where(r => DbFunctions.TruncateTime(r.dateOfAdmission) == date.Date)
                //        .ToList();

            }
        }

        public Patientrecord GetPatientByMedicalCondition(string condition)
        {
            using (MVCApiRecordEntities mVCApiRecordEntities = new MVCApiRecordEntities())
            {
                return mVCApiRecordEntities.Patientrecords
                    .FirstOrDefault(r => r.medicalCondition.Equals(condition, StringComparison.OrdinalIgnoreCase));

            }
        }

        public void AddPatientRecord(Patientrecord patientrecord)
        {
            using (MVCApiRecordEntities mVCApiRecordEntities = new MVCApiRecordEntities())
            {
                mVCApiRecordEntities.Patientrecords.Add(patientrecord);
                mVCApiRecordEntities.SaveChanges();
            }
        }

        public void UpdatePatientRecord(Patientrecord patientrecord)
        {
            using (MVCApiRecordEntities mVCApiRecordEntities = new MVCApiRecordEntities())
            {
                var record = (from r in mVCApiRecordEntities.Patientrecords
                              where r.id == patientrecord.id
                              select r).First();
                if (record == null)
                {
                    return;
                }
                record.medicalCondition = patientrecord.medicalCondition;
                record.billingAmount = patientrecord.billingAmount;
                record.roomNumber = patientrecord.roomNumber;
                record.dischargeDate = patientrecord.dischargeDate;
                record.medication = patientrecord.medication;
                record.testResults = patientrecord.testResults;

                mVCApiRecordEntities.SaveChanges();
            }
        }

        public void DeletePatientRecord(string Id)
        {
            using (MVCApiRecordEntities mVCApiRecordEntities = new MVCApiRecordEntities())
            {
                var record = mVCApiRecordEntities.Patientrecords
                    .FirstOrDefault(r => r.id.Equals(Id, StringComparison.OrdinalIgnoreCase));
                if (record == null)
                {
                    return;
                }
                mVCApiRecordEntities.Patientrecords.Remove(record);
                mVCApiRecordEntities.SaveChanges();
            }
        }

    }
}
