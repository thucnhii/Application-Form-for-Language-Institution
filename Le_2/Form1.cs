// Programmer: Hoai Thuc Nhi Le
// Project: Le_2
// Due Date: 02/24/2023
// Description: Individual Assignment #2

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Le_2
{
    public partial class laiOrderEntry : Form
    {
        public laiOrderEntry()
        {
            InitializeComponent();
        }

        // Constant Variables
        private const decimal IN_STATE_PRICE = 49m;
        private const decimal OUT_OF_STATE_PRICE = 99m;

        // Display the default when starting the form
        private void laiOrderEntry_Load(object sender, EventArgs e)
        {
            priceLabel.Text = IN_STATE_PRICE.ToString("c");  //In-state price is default
            fallButton.Checked = true;      //Fall term is default
            inStateButton.Checked = true;   //In-state status is default
            masterCardButton.Checked = true;    //MasterCard is default
            totCoursesLabel.Text = "0";
            totPriceLabel.Text = "0";
            yearComboBox.SelectedIndex = -1;
        }

        // The price per course and total price will automatically change when residence status is changed
        private void outOfStateButton_CheckedChanged(object sender, EventArgs e)
        {
            // Change the price per course when residence status is changed
            if (outOfStateButton.Checked)
                priceLabel.Text = OUT_OF_STATE_PRICE.ToString("c");
            else
                priceLabel.Text = IN_STATE_PRICE.ToString("c");

            // local variables
            decimal numOfCourse = 0m;   // Total Course
            decimal totalPrice = 0m;    // Total Price
            decimal pricePerCourse;     // Price per course

            // Assign values to price per course based on the residence status
            if (outOfStateButton.Checked)
            
                pricePerCourse = OUT_OF_STATE_PRICE;
            
            else
            
                pricePerCourse = IN_STATE_PRICE;
            

            // Count the total number of course checked.
            if (frenchCheckBox.Checked)
            
                numOfCourse += 1;
            
            if (germanCheckBox.Checked)
            
                numOfCourse += 1;
            
            if (italianCheckBox.Checked)
            
                numOfCourse += 1;
            
            if (russianCheckBox.Checked)
            
                numOfCourse += 1;
            
            if (spanishCheckBox.Checked)
                numOfCourse += 1;

            // Calculate the total price
            totalPrice = numOfCourse * pricePerCourse;

            // Display the total price
            totPriceLabel.Text = totalPrice.ToString("c");



        }
        //Shared event handler for the checkboxes
        //When the check box is checked, automically change the total course and total price
        //When the number of courses checked>3, show error message
        private void frenchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Local variables
            decimal numOfCourse = 0m;
            decimal totalPrice = 0m;
            decimal pricePerCourse;

            //Assign values to price per course based on the residence status
            if (outOfStateButton.Checked) 
                pricePerCourse = OUT_OF_STATE_PRICE;
            else
                pricePerCourse = IN_STATE_PRICE;

            //Count the total number or course checked.
            if (frenchCheckBox.Checked)
                numOfCourse += 1;
            if (germanCheckBox.Checked) 
                numOfCourse += 1;
            if (italianCheckBox.Checked)
                numOfCourse += 1;
            if (russianCheckBox.Checked)
                numOfCourse += 1;
            if (spanishCheckBox.Checked)
                numOfCourse += 1;

            //Calculate the total price
            totalPrice = numOfCourse * pricePerCourse;

            //If the total number of course is more than 3, show error message
            if (numOfCourse > 3)
            {
                MessageBox.Show("The number of courses can't be more than 3"
                    , "Error Message"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Exclamation);
                totCoursesLabel.Text = numOfCourse.ToString();
            }
            else
            {
                totCoursesLabel.Text = numOfCourse.ToString();
                totPriceLabel.Text = totalPrice.ToString("c");
            }

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //Use try-catch method to prevent errors from stopping the program.
            try
            {
                // Input validation for the three masked textbox 
                if (!idTextBox.MaskCompleted)
                {
                    MessageBox.Show("Invalid Student ID"
                        , "Error Message"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Exclamation );
                    idTextBox.Focus();
                }
                else if (!cardNumberTextBox.MaskCompleted)
                {
                    MessageBox.Show("Invalid Card Number"
                        ,"Error Message"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Exclamation );
                    cardNumberTextBox.Focus();

                }
                else if (!expirationDateTextBox.MaskCompleted)
                {
                    MessageBox.Show("Invalid Expiration Date"
                        , "Error Message"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Exclamation );
                    expirationDateTextBox.Focus();
                }
                else
                {
                    // Local Variable for the summary message box
                    string term
                        , year
                        , studentID
                        , fullName
                        , email
                        , residence
                        , totalCoursePurchased
                        , pricePerCourse
                        , totalOrderPrice
                        , cardType
                        , cardNumber
                        , cardExpirationDate
                        , french
                        , german
                        , italian
                        , russian
                        , spanish;
                    
                    //Prepare the input to get it show in the message box
                    year = yearComboBox.SelectedItem.ToString();
                    studentID = idTextBox.Text;
                    fullName = firstNameTextBox.Text + " " + lastNameTextBox.Text;
                    email = emailTextBox.Text;
                    totalCoursePurchased = totCoursesLabel.Text;
                    pricePerCourse = pricePerCourseLabel.Text;
                    totalOrderPrice = totPriceLabel.Text;
                    cardNumber = cardNumberTextBox.Text;
                    cardExpirationDate = expirationDateTextBox.Text;

                    //Term
                    if (fallButton.Checked)
                        term = "Fall";
                    else
                        term = "Spring";

                    //Residence Status
                    if (inStateButton.Checked)
                        residence = "In-State";
                    else
                        residence = "Out-Of-State";

                    //Card Type
                    if (masterCardButton.Checked)
                        cardType = "MasterCard";
                    else
                        cardType = "Visa";

                    //French
                    if (frenchCheckBox.Checked)
                        french = "Beginning French" + "\n";
                    else
                        french = null;

                    //German
                    if (germanCheckBox.Checked)
                        german = "Beginning German" + "\n";
                    else
                        german = null;

                    //Italian
                    if (italianCheckBox.Checked)
                        italian = "Beginning Italian" + "\n";
                    else
                        italian = null;

                    //Russian
                    if (russianCheckBox.Checked)
                        russian = "Beginning Russian" + "\n";
                    else
                        russian = null;

                    //Spanish
                    if (spanishCheckBox.Checked)
                        spanish = "Beginning Spanish" + "\n";
                    else
                        spanish = null;

                    //Summary MessageBox. if number of course >3 or <1, show error message
                    // If not, display the summary messagebox
                    if (decimal.Parse(totCoursesLabel.Text) >3 || 
                        decimal.Parse(totCoursesLabel.Text) <1)
                    {
                        MessageBox.Show("The number of courses must be at least 1 but no more than 3"
                            , "Error Message"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Exclamation);

                    }
                    else
                    {
                        MessageBox.Show("Registration Term: " + term + " " + year + "\n" +
                            "Student ID: " + studentID + "\n" +
                            "Student Name: " + fullName + "\n" +
                            "Email Address: " + email + "\n" +
                            "Residence Status: " + residence + "\n\n" +
                            "Total Course Purchased: " + totalCoursePurchased + "\n" +
                            "Price per Course: " + pricePerCourse + "\n" +
                            "Total Order Price: " + totalOrderPrice + "\n\n" +
                            "Credit Card Type: " + cardType + "\n" +
                            "Card Number: " + cardNumber + "\n" +
                            "Expiration Date: " + cardExpirationDate + "\n" +
                            "Course Order: \n" +
                            french +
                            german +
                            italian +
                            russian +
                            spanish
                            , "Order Summary"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill in all required information."
                    , "Error Message"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Exclamation);
            }
        }

        //Click the clear button to reset the program to its original form.
        private void clearButton_Click(object sender, EventArgs e)
        {
            fallButton.Checked = true;
            yearComboBox.SelectedIndex = -1;
            idTextBox.Text = " ";
            firstNameTextBox.Text = " ";
            lastNameTextBox.Text = " ";
            emailTextBox.Text = " ";
            inStateButton.Checked = true;
            frenchCheckBox.Checked = false;
            germanCheckBox.Checked = false;
            italianCheckBox.Checked = false;
            russianCheckBox.Checked = false;
            spanishCheckBox.Checked = false;
            masterCardButton.Checked = true;
            cardNumberTextBox.Text = " ";
            expirationDateTextBox.Text = " ";
            fallButton.Focus();
            priceLabel.Text = " ";
            totCoursesLabel.Text = " ";
            totPriceLabel.Text = " ";

        }

        //Click the exit button and a pop-up appears.
        //If yes, close the form. If no, close the messagebox
        private void exitButton_Click(object sender, EventArgs e)
        {
            //Close the form
            DialogResult dialog = MessageBox.Show("Are you sure you wish to quit?"
                , "Quit"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Question );
            if (dialog == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
        
        
         
