using System;
using System.Collections.Generic;
using System.Linq;

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
                List<Patientrecord> list = (from record in mVCApiRecordEntities.Patientrecords
                                            select new Patientrecord
                                            {
                                                id = record.id,
                                                name = record.name,
                                                email = record.email,
                                                age = record.age ?? 0, // Nullable types need conversion
                                                gender = record.gender,
                                                bloodType = record.bloodType,
                                                medicalCondition = record.medicalCondition,
                                                dateOfAdmission = record.dateOfAdmission ?? DateTime.MinValue,
                                                doctor = record.doctor,
                                                hospital = record.hospital,
                                                insuranceProvider = record.insuranceProvider,
                                                billingAmount = (decimal?)(double)(record.billingAmount ?? 0),
                                                roomNumber = record.roomNumber ?? 0,
                                                admissionType = record.admissionType,
                                                dischargeDate = record.dischargeDate ?? DateTime.MinValue,
                                                medication = record.medication,
                                                testResults = record.testResults
                                            }).ToList();

                return list;
            }
        }

        public Patientrecord GetPatientRecordByID(int Id)
        {
            using (MVCApiRecordEntities mVCApiRecordEntities = new MVCApiRecordEntities())
            {
                var patientRecordEntity = mVCApiRecordEntities.Patientrecords
                                         .FirstOrDefault(record => record.id == Id.ToString()); // Convert Id to string

                if (patientRecordEntity == null)
                {
                    return null;
                }

                // Map the entity to the PatientRecord class
                Patientrecord patientRecord = new Patientrecord
                {
                    id = patientRecordEntity.id,
                    name = patientRecordEntity.name,
                    email = patientRecordEntity.email,
                    age = patientRecordEntity.age ?? 0,
                    gender = patientRecordEntity.gender,
                    bloodType = patientRecordEntity.bloodType,
                    medicalCondition = patientRecordEntity.medicalCondition,
                    dateOfAdmission = patientRecordEntity.dateOfAdmission ?? DateTime.MinValue,
                    doctor = patientRecordEntity.doctor,
                    hospital = patientRecordEntity.hospital,
                    insuranceProvider = patientRecordEntity.insuranceProvider,
                    billingAmount = (decimal?)(double)(patientRecordEntity.billingAmount ?? 0),
                    roomNumber = patientRecordEntity.roomNumber ?? 0,
                    admissionType = patientRecordEntity.admissionType,
                    dischargeDate = patientRecordEntity.dischargeDate ?? DateTime.MinValue,
                    medication = patientRecordEntity.medication,
                    testResults = patientRecordEntity.testResults
                };

                return patientRecord;
            }
        }

        public Patientrecord GetEmployeeByName(Patientrecord patientrecord)
        {
            using (MVCApiRecordEntities mVCApiRecordEntities = new MVCApiRecordEntities())
            {
                var record = mVCApiRecordEntities.Patientrecords
                    .FirstOrDefault(r => r.name.Equals(patientrecord.name, StringComparison.OrdinalIgnoreCase));

                if (record == null)
                {
                    return null;
                }
                return record;
            }
        }

        public Patientrecord GetPatientrecordByBloodGroud(Patientrecord patientrecord)
        {
            using (MVCApiRecordEntities mVCApiRecordEntities = new MVCApiRecordEntities())
            {
                var record = mVCApiRecordEntities.Patientrecords
                    .FirstOrDefault(r => r.bloodType.Equals(patientrecord.bloodType, StringComparison.OrdinalIgnoreCase));

                if (record == null) {
                    return null;
                }
                return record;
            }
        }

        public Patientrecord GetPatientAdmitDate(DateTime dateTime)
        {
            using (MVCApiRecordEntities mVCApiRecordEntities = new MVCApiRecordEntities())
            {
                var record = mVCApiRecordEntities.Patientrecords
                    .FirstOrDefault(r => r.dateOfAdmission == dateTime);

                if (record == null)
                {
                    return null;
                }
                return record;
            }
        }

        public Patientrecord GetPatientByMedicalCondition(string condition)
        {
            using (MVCApiRecordEntities mVCApiRecordEntities = new MVCApiRecordEntities())
            {
                var record = mVCApiRecordEntities.Patientrecords
                    .FirstOrDefault(r => r.medicalCondition.Equals(condition, StringComparison.OrdinalIgnoreCase));

                if (record == null)
                {
                    return null;
                }
                return record;
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

        public void DeletePatientRecord(int Id)
        {
            using (MVCApiRecordEntities mVCApiRecordEntities = new MVCApiRecordEntities())
            {
                var record = mVCApiRecordEntities.Patientrecords
                    .FirstOrDefault(r => r.id == Id.ToString());
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
