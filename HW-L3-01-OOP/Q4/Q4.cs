namespace HW_L3;

using System;
using System.Collections.Generic;

// Custom room exception
class RoomFullException : Exception
{
    public RoomFullException(string message)
        : base(message)
    {
    }
}


// Base person class
class Person
{
    // Common person data
    public string Name { get; set; }
    public int Age { get; set; }
    public string NationalId { get; set; }

    // Create person object
    public Person(string name, int age, string nationalId)
    {
        Name = name;
        Age = age;
        NationalId = nationalId;
    }

    // Return person details
    public virtual string GetDetails()
    {
        return $"{Name} - {Age} - {NationalId}";
    }
}


// Patient class
class Patient : Person
{
    // Patient properties
    public int PatientId { get; set; }
    public List<string> MedicalHistory { get; set; }

    // Create patient object
    public Patient(
        string name,
        int age,
        string nationalId,
        int patientId)
        : base(name, age, nationalId)
    {
        PatientId = patientId;
        MedicalHistory = new List<string>();
    }

    // Add medical history
    public void AddToMedicalHistory(string history)
    {
        MedicalHistory.Add(history);
    }
}


// Doctor class
class Doctor : Person
{
    // Doctor properties
    public int DoctorId { get; set; }
    public string Specialization { get; set; }

    // Create doctor object
    public Doctor(
        string name,
        int age,
        string nationalId,
        int doctorId,
        string specialization)
        : base(name, age, nationalId)
    {
        DoctorId = doctorId;
        Specialization = specialization;
    }

    // Diagnose patient
    public void Diagnose(
        Patient patient,
        string diagnosis)
    {
        patient.AddToMedicalHistory(diagnosis);
    }
}


// Hospital room class
class Room
{
    // Room information
    public int RoomNumber { get; set; }
    public int Capacity { get; set; }

    public List<Patient> Patients { get; set; }

    // Create room object
    public Room(int number, int capacity)
    {
        RoomNumber = number;
        Capacity = capacity;
        Patients = new List<Patient>();
    }

    // Assign patient room
    public void AssignPatient(Patient patient)
    {
        if (Patients.Count >= Capacity)
        {
            throw new RoomFullException(
                "Room is full"
            );
        }

        Patients.Add(patient);
    }
}


// Hospital singleton class
class Hospital
{
    // Single hospital instance
    private static Hospital instance;

    public List<Doctor> Doctors { get; set; }
    public List<Room> Rooms { get; set; }

    // Private constructor
    private Hospital()
    {
        Doctors = new List<Doctor>();
        Rooms = new List<Room>();
    }

    // Get hospital instance
    public static Hospital Instance
    {
        get
        {
            if (instance == null)
                instance = new Hospital();

            return instance;
        }
    }

    // Admit new patient
    public void AdmitPatient(Patient patient)
    {
        foreach (Room room in Rooms)
        {
            try
            {
                room.AssignPatient(patient);
                WriteLine("Patient added");
                return;
            }
            catch (RoomFullException)
            {

            }
        }

        WriteLine("No rooms available");
    }

    // Remove patient
    public void DischargePatient(Patient patient)
    {
        foreach (Room room in Rooms)
        {
            room.Patients.Remove(patient);
            WriteLine("Patient Remove Successfully");
        }
    }
}


// Main program
class Question4
{
    public static void Q4()
    {
        WriteLine("=== Hospital System Started ===");


        // Get singleton hospital
        Hospital hospital = Hospital.Instance;

        WriteLine("Hospital instance created");


        // Create room with capacity 1
        Room room1 = new Room(101, 1);

        hospital.Rooms.Add(room1);

        WriteLine(
            $"Room {room1.RoomNumber} created with capacity {room1.Capacity}"
        );


        // Create first patient
        Patient patient1 = new Patient(
            "Ali",
            25,
            "123456",
            1
        );

        WriteLine(
            "First patient created"
        );


        // Create second patient
        Patient patient2 = new Patient(
            "Sara",
            30,
            "555555",
            2
        );

        WriteLine(
            "Second patient created"
        );


        // Create doctor
        Doctor doctor = new Doctor(
            "Dr Smith",
            45,
            "987654",
            10,
            "Heart"
        );

        WriteLine(
            "Doctor created"
        );


        // Diagnose patients
        doctor.Diagnose(
            patient1,
            "Heart check completed"
        );

        WriteLine(
            "Doctor diagnosed patient Ali"
        );


        WriteLine();
        WriteLine("Adding patients to room...");


        try
        {
            // First patient accepted
            room1.AssignPatient(patient1);

            WriteLine(
                $"{patient1.Name} added to room {room1.RoomNumber}"
            );


            // Second patient causes exception
            room1.AssignPatient(patient2);

            WriteLine(
                $"{patient2.Name} added to room {room1.RoomNumber}"
            );

        }
        catch (RoomFullException ex)
        {
            WriteLine(
                "Exception happened!"
            );

            WriteLine(
                ex.Message
            );
        }


        WriteLine();
        WriteLine("Patient information:");

        WriteLine(
            patient1.GetDetails()
        );


        WriteLine();
        WriteLine("Discharging patient...");


        hospital.DischargePatient(patient1);


        WriteLine(
            $"{patient1.Name} removed from hospital"
        );


        WriteLine();
        WriteLine("=== System Finished ===");
    }
}