import React, { useEffect, useState } from "react";
import "../Booking/Booking.css";

function Booking() {
  const [numberOfTravellers, setNumberOfTravellers] = useState(1);
  const [Booking, setBookingDetails] = useState({
    tourId: 0,
    userId: 0,
    bookingDate: new Date().toISOString(),
    bookingStatus: "successful",
    contactName: "",
    contactEmail: "",
    phoneNumber: "",
    totalPrice: 0,
    passengers: [
      {
        name: "",
        age: "",
        gender: "",
      },
    ],
  });

  const handleTravellerDetailsChange = (index, field, value) => {
    const updatedPassengers = Booking.passengers.map((passenger, i) => {
      if (i === index) {
        return {
          ...passenger,
          [field]: value,
        };
      }
      return passenger;
    });

    setBookingDetails((prevBooking) => ({
      ...prevBooking,
      passengers: updatedPassengers,
    }));
  };
  useEffect(() => {
    const date = new Date();
    const storedTravellerCount = localStorage.getItem("TravellerCount");
    const tourId = parseInt(localStorage.getItem("TourId"), 10);
    const userId = parseInt(localStorage.getItem("id"), 10);
    const tourPrice = parseInt(localStorage.getItem("TourPrice"), 10);

    setBookingDetails((prevBooking) => ({
      ...prevBooking,
      tourId: tourId,
      userId: userId,
      totalPrice: tourPrice * storedTravellerCount,
    }));

    if (storedTravellerCount !== null && !isNaN(storedTravellerCount)) {
      setNumberOfTravellers(parseInt(storedTravellerCount, 10));
    }
  }, []);

  const divArray = new Array(numberOfTravellers).fill(null);

  const BookTour = () => {
    fetch("http://localhost:5011/api/Booking/AddBooking", {
      method: "POST",
      headers: {
        accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ ...Booking }),
    })
      .then(async (response) => {
        const data = await response.json();
      })
      .catch((err) => {
        console.log(err.error);
      });
  };

  return (
    <div className="Booking">
      <div className="BookingHeader">
        <div>
          <h1 className="BookingHeading">Book Your Package</h1>
        </div>
        <div className="BookingDescription">
          MakeYourTrip is one of the most popular Travel agency for those who
          want to explore the world and try to make adventure
        </div>
      </div>
      <div className="BookingCredentialData">
        <div className="BookingCredentialLabelInput">
          <label className="addBookingInputLable">Name</label>
          <input
            type="text"
            placeholder="Contact name"
            className="addBookingInputField"
            onChange={(e) => {
              setBookingDetails({ ...Booking, contactName: e.target.value });
            }}
          />
        </div>
        <div className="BookingCredentialLabelInput">
          <label className="addBookingInputLable">Email</label>
          <input
            type="text"
            placeholder="Contact email"
            className="addBookingInputField"
            onChange={(e) => {
              setBookingDetails({ ...Booking, contactEmail: e.target.value });
            }}
          />
        </div>
        <div className="BookingCredentialLabelInput">
          <label className="addBookingInputLable">Phone Number</label>
          <input
            type="text"
            placeholder="Phone number"
            className="addBookingInputField"
            onChange={(e) => {
              setBookingDetails({ ...Booking, phoneNumber: e.target.value });
            }}
          />
        </div>
      </div>
      <div className="BookinngTravellerInputContainer">
        <div className="BookingTravellerHeader">
          <div>
            <h2>Travellers Details</h2>
          </div>
          {divArray.map((traveller, index) => (
            <div key={index} className="TravllerInputCredentialContainer">
              {/* ... (other JSX code) */}
              <div className="BookingCredentialLabelInput">
                <label className="addBookingInputLable">Traveller Name</label>
                <input
                  type="text"
                  className="addBookingInputField"
                  placeholder="Traveller name"
                  onChange={(e) => {
                    handleTravellerDetailsChange(index, "name", e.target.value);
                  }}
                />
              </div>
              <div className="BookingCredentialLabelInput">
                <label className="addBookingInputLable">Age</label>
                <input
                  className="addBookingInputField"
                  type="text"
                  placeholder="Age"
                  onChange={(e) => {
                    handleTravellerDetailsChange(index, "age", e.target.value);
                  }}
                />
              </div>
              <div className="BookingCredentialLabelInput">
                <label className="addBookingInputLable">Gender</label>
                <select
                  className="addBookingInputField"
                  onChange={(e) => {
                    handleTravellerDetailsChange(
                      index,
                      "gender",
                      e.target.value
                    );
                  }}
                >
                  <option value="">Select</option>
                  <option value="Male">Male</option>
                  <option value="FeMale">Female</option>
                  <option value="Other">Other</option>
                </select>
              </div>
            </div>
          ))}
        </div>
      </div>
      <div>
        <span className="packageStartFromTourDetails">Price </span>
        <span className="packageStartFromPriceTourDetails">
          ${Booking.totalPrice}
        </span>
      </div>
      <div>
        <button
          className="payBookNowButton"
          onClick={() => {
            BookTour();
          }}
        >
          Pay & BookNow
        </button>
      </div>
    </div>
  );
}

export default Booking;
