using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class InfoManager : MonoBehaviour
{
    public Text Name;
    public Text Gender;
    public Text BirthDate;
    public Text MaritialStatus;
    public Text Language;
    public Text Address;
    public Text MedicalRecordNumber;
    public Text SocialSecurityNumber;
    public Text DriversLicense;
    public Text PassportNumber;
    public GameObject NextButton;
    public GameObject PreviousButton;
    public GameObject Female;
    public GameObject Male;
    
    private int i = 0;
    private GetData GetDataScript;
    // Start is called before the first frame update
    void Start()
    {
        GetDataScript = GameObject.Find("Launcher").GetComponent<GetData>();
        if (GetDataScript.patients.entry[0].resource.gender == "male")
        {
            Male.SetActive(true);
            Female.SetActive(false);
        }
        else
        {
            Male.SetActive(false);
            Female.SetActive(true);
        }

        Debug.Log(GetDataScript.patients.entry.Length);
        try
        {
            Name.text = GetDataScript.patients.entry[i].resource.name[0].prefix[0] + " " +
           GetDataScript.patients.entry[i].resource.name[0].given[0] + " " +
           GetDataScript.patients.entry[i].resource.name[0].family;
        }
        catch
        {
            Name.text = GetDataScript.patients.entry[i].resource.name[0].given[0] + " " +
           GetDataScript.patients.entry[i].resource.name[0].family;
        }


        Gender.text = GetDataScript.patients.entry[0].resource.gender;
        BirthDate.text = GetDataScript.patients.entry[0].resource.birthDate;
        MaritialStatus.text = GetDataScript.patients.entry[0].resource.maritalStatus.text;
        Language.text = GetDataScript.patients.entry[0].resource.communication[0].language.text;
        Address.text = GetDataScript.patients.entry[0].resource.address[0].line[0] + Environment.NewLine +
           GetDataScript.patients.entry[0].resource.address[0].city + "," +
            GetDataScript.patients.entry[0].resource.address[0].state + Environment.NewLine +
            GetDataScript.patients.entry[0].resource.address[0].postalCode + "," +
            GetDataScript.patients.entry[0].resource.address[0].country;
        if(GetDataScript.patients.entry[0].resource.identifier[1].type.text=="Medical Record Number")
        {
            MedicalRecordNumber.text = GetDataScript.patients.entry[0].resource.identifier[1].value;
        }
        else
        {
            MedicalRecordNumber.text = "N/A";
        }
        if (GetDataScript.patients.entry[0].resource.identifier[2].type.text == "Social Security Number")
        {
            SocialSecurityNumber.text = GetDataScript.patients.entry[0].resource.identifier[2].value;
        }
        else
        {
            SocialSecurityNumber.text = "N/A";
        }
        if (GetDataScript.patients.entry[0].resource.identifier[3].type.text == "Driver's License")
        {
            DriversLicense.text = GetDataScript.patients.entry[0].resource.identifier[3].value;
        }
        else
        {
            DriversLicense.text = "N/A";
        }
        if (GetDataScript.patients.entry[0].resource.identifier[4].type.text == "Passport Number")
        {
            PassportNumber.text = GetDataScript.patients.entry[0].resource.identifier[4].value;
        }
        else
        {
            PassportNumber.text = "N/A";
        }

    } 

    // Update is called once per frame
    void Update()
    {

        if (CrossPlatformInputManager.GetButtonDown("Next"))
        {
            i++;
            PreviousButton.SetActive(true);
            if (i == GetDataScript.patients.entry.Length - 1)
            {
                NextButton.SetActive(false);
            }



            if (GetDataScript.patients.entry[i].resource.gender == "male")
            {
                Male.SetActive(true);
                Female.SetActive(false);
            }
            else
            {
                Male.SetActive(false);
                Female.SetActive(true);
            }


            Debug.Log(i);

            try
            {
                Name.text = GetDataScript.patients.entry[i].resource.name[0].prefix[0] + " " +
               GetDataScript.patients.entry[i].resource.name[0].given[0] + " " +
               GetDataScript.patients.entry[i].resource.name[0].family;
            }
            catch
            {
                Name.text = GetDataScript.patients.entry[i].resource.name[0].given[0] + " " +
               GetDataScript.patients.entry[i].resource.name[0].family;
            }

            Gender.text = GetDataScript.patients.entry[i].resource.gender;
            BirthDate.text = GetDataScript.patients.entry[i].resource.birthDate;
            MaritialStatus.text = GetDataScript.patients.entry[i].resource.maritalStatus.text;
            Language.text = GetDataScript.patients.entry[i].resource.communication[0].language.text;
            Address.text = GetDataScript.patients.entry[i].resource.address[0].line[0] + Environment.NewLine +
                GetDataScript.patients.entry[i].resource.address[0].city + "," +
                GetDataScript.patients.entry[i].resource.address[0].state + Environment.NewLine +
                GetDataScript.patients.entry[i].resource.address[0].postalCode + "," +
                GetDataScript.patients.entry[i].resource.address[0].country;

            if (GetDataScript.patients.entry[i].resource.identifier[1].type.text == "Medical Record Number")
            {
                MedicalRecordNumber.text = GetDataScript.patients.entry[i].resource.identifier[1].value;
            }
            else
            {
                MedicalRecordNumber.text = "N/A";
            }
            if (GetDataScript.patients.entry[i].resource.identifier[2].type.text == "Social Security Number")
            {
                SocialSecurityNumber.text = GetDataScript.patients.entry[i].resource.identifier[2].value;
            }
            else
            {
                SocialSecurityNumber.text = "N/A";
            }
            if (GetDataScript.patients.entry[i].resource.identifier[3].type.text == "Driver's License")
            {
                DriversLicense.text = GetDataScript.patients.entry[i].resource.identifier[3].value;
            }
            else
            {
                DriversLicense.text = "N/A";
            }
            if (GetDataScript.patients.entry[i].resource.identifier[4].type.text == "Passport Number")
            {
                PassportNumber.text = GetDataScript.patients.entry[i].resource.identifier[4].value;
            }
            else
            {
                PassportNumber.text = "N/A";
            }
        }

        if (CrossPlatformInputManager.GetButtonDown("Previous"))
        {
            i=i-1;
            NextButton.SetActive(true);
            if (i == 0)
            {
                PreviousButton.SetActive(false);
            }



            if (GetDataScript.patients.entry[i].resource.gender == "male")
            {
                Male.SetActive(true);
                Female.SetActive(false);
            }
            else
            {
                Male.SetActive(false);
                Female.SetActive(true);
            }


            Debug.Log(i);


            try
            {
                Name.text = GetDataScript.patients.entry[i].resource.name[0].prefix[0] + " " +
               GetDataScript.patients.entry[i].resource.name[0].given[0] + " " +
               GetDataScript.patients.entry[i].resource.name[0].family;
            }
            catch
            {
                Name.text = GetDataScript.patients.entry[i].resource.name[0].given[0] + " " +
               GetDataScript.patients.entry[i].resource.name[0].family;
            }

            Gender.text = GetDataScript.patients.entry[i].resource.gender;
            BirthDate.text = GetDataScript.patients.entry[i].resource.birthDate;
            MaritialStatus.text = GetDataScript.patients.entry[i].resource.maritalStatus.text;
            Language.text = GetDataScript.patients.entry[i].resource.communication[0].language.text;
            Address.text = GetDataScript.patients.entry[i].resource.address[0].line[0] + Environment.NewLine +
                GetDataScript.patients.entry[i].resource.address[0].city + "," +
                GetDataScript.patients.entry[i].resource.address[0].state + Environment.NewLine +
                GetDataScript.patients.entry[i].resource.address[0].postalCode + "," +
                GetDataScript.patients.entry[i].resource.address[0].country;

            if (GetDataScript.patients.entry[i].resource.identifier[1].type.text == "Medical Record Number")
            {
                MedicalRecordNumber.text = GetDataScript.patients.entry[i].resource.identifier[1].value;
            }
            else
            {
                MedicalRecordNumber.text = "N/A";
            }
            if (GetDataScript.patients.entry[i].resource.identifier[2].type.text == "Social Security Number")
            {
                SocialSecurityNumber.text = GetDataScript.patients.entry[i].resource.identifier[2].value;
            }
            else
            {
                SocialSecurityNumber.text = "N/A";
            }
            if (GetDataScript.patients.entry[i].resource.identifier[3].type.text == "Driver's License")
            {
                DriversLicense.text = GetDataScript.patients.entry[i].resource.identifier[3].value;
            }
            else
            {
                DriversLicense.text = "N/A";
            }
            if (GetDataScript.patients.entry[i].resource.identifier[4].type.text == "Passport Number")
            {
                PassportNumber.text = GetDataScript.patients.entry[i].resource.identifier[4].value;
            }
            else
            {
                PassportNumber.text = "N/A";
            }
        }
    }
}
