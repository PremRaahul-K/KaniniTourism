import React, { useState, useEffect } from "react";
import "../TourPackage/TourPackage.css";
import { useNavigate, useParams } from "react-router-dom";

function TourPackage() {
  const navigate = useNavigate();
  const [showExclusion, setExclusion] = useState(false);
  const [showInclusion, setInclusion] = useState(true);
  const [selectedDates, setSelectedDates] = useState(null);
  const [bookingApproval, setBookingApproval] = useState(false);
  const [bookingError, setBookingError] = useState(false);
  const [validateBooking, setValidateBooking] = useState({
    travellerCount: 0,
    dateId: 0,
  });

  const handleDateSelection = (departureDate, returnDate) => {
    setSelectedDates({ departureDate, returnDate });
  };

  const handleReservation = () => {
    if (selectedDates) {
      fetch("http://localhost:5129/api/Tour/ValidateBooking", {
        method: "POST",
        headers: {
          accept: "application/json",
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ ...validateBooking }),
      })
        .then(async (response) => {
          const data = await response.json();
          if (data.validationStatus == "approved") {
            setBookingApproval(true);
            setBookingError(false);
          } else {
            setBookingApproval(false);
            setBookingError(true);
          }
        })
        .catch((err) => {
          console.log(err.error);
        });
    }
  };

  const handleShowInclusion = () => {
    setInclusion(true);
    setExclusion(false);
  };

  const handleShowExclusion = () => {
    setInclusion(false);
    setExclusion(true);
  };
  const [agentDetails, setAgentDetails] = useState({
    travelAgent: {
      travelAgentId: 0,
      agencyName: "",
      status: "",
    },
    userId: 0,
    firstName: "",
    lastName: "",
    email: "",
    age: 0,
    dateOfBirth: "",
    phoneNumber: "",
    address: "",
    gender: "",
    nationality: "",
  });
  const [tourPackage, setTourPackage] = useState({
    tourId: 0,
    travelAgentId: 0,
    name: "",
    description: "",
    tourType: "",
    numberOfDays: 0,
    price: "",
    imageUrl: "",
    foodAccommodation: "",
    tourDates: [
      {
        dateId: 0,
        tourId: 0,
        capacity: 0,
        bookedCapacity: 0,
        numberOfDays: 0,
        departureDate: "",
        returnDate: "",
      },
    ],
    tourItinerary: [
      {
        tourItineraryId: 0,
        tourId: 0,
        title: "",
        imageUrl: "",
        itineraries: [
          {
            itineraryId: 0,
            activityTitle: "",
            activityDescription: "",
            location: "",
            tourItineraryId: 0,
          },
        ],
        accommodation: {
          hotelId: 0,
          hotelName: "",
          address: "",
          tourItineraryId: 0,
        },
      },
    ],
    pickupLocation: [
      {
        pickupLocationId: 0,
        pickupLocationName: "",
        pickupTime: "",
      },
    ],
    highlight: [
      {
        highlightId: 0,
        tourId: 0,
        highlightDetails: "",
      },
    ],
    inclusion: [
      {
        inclusionId: 0,
        tourId: 0,
        inclusionDetails: "",
      },
    ],
    exclusion: [
      {
        exclusionId: 0,
        tourId: 0,
        exclusionDetails: "",
      },
    ],
  });
  const { id } = useParams();
  useEffect(() => {
    fetch("http://localhost:5129/api/Tour/GetTour?id=" + id, {
      method: "POST",
      headers: {
        accept: "application/json",
        "Content-Type": "application/json",
      },
    })
      .then(async (response) => {
        const data = await response.json();
        setTourPackage(data);
        console.log(data);
        GetAgentDetails(data.travelAgentId);
      })
      .catch((err) => {
        console.log(err.error);
      });
  }, []);

  const GetAgentDetails = (agentId) => {
    fetch(
      "http://localhost:5115/api/TravelAgent/GetTravelAgent?id=" + agentId,
      {
        method: "POST",
        headers: {
          accept: "application/json",
          "Content-Type": "application/json",
        },
      }
    )
      .then(async (response) => {
        const data = await response.json();
        setAgentDetails(data);
        console.log(data);
      })
      .catch((err) => {
        console.log(err.error);
      });
  };
  return (
    <div className="TourPackage">
      <div className="tourPackageHeader">
        <div>
          <h1>{tourPackage.name} tour Package</h1>
        </div>
        <div className="tourDescription">
          <span className="makeMyTripTravelQuote">
            Make your trip is one of the most popular Travel agency for those
            who want to explore the world and try to make adventure
          </span>
        </div>
      </div>
      <div className="tourPackageTitleDescription">
        <div className="tourPackageImageContainer">
          <img
            src={
              "https://assets.website-files.com/63b51b3ba52a4df601298f55/63ccca0d0949d93d5c2a40ed_package-image%20(12).jpg"
            }
            className="tourPackageImage"
          />
        </div>
        <div className="tourPackageTitleDescriptionData">
          <div>
            <span className="tourPackageDayCount">
              {tourPackage.numberOfDays} Day {tourPackage.numberOfDays - 1}{" "}
              Night
            </span>
            <h2 className="tourPackageSectionHeader">
              Explore the Beauty of {tourPackage.name} and enjoy
            </h2>
            <p>{tourPackage.description}</p>
          </div>
          <div className="tourPackagePriceDetails">
            <div>
              <span className="packageStartFromTourDetails">Price </span>
              <span className="packageStartFromPriceTourDetails">
                ${tourPackage.price}
              </span>
            </div>
          </div>
          <div className="tourPackageBooking">
            <div>
              <h3 className="">Available Dates:</h3>
              <ul className="depatureReturn">
                {tourPackage.tourDates.map((date) => (
                  <div key={date.dateId}>
                    {date.capacity != date.bookedCapacity && (
                      <li
                        onClick={() => {
                          handleDateSelection(
                            date.departureDate,
                            date.returnDate
                          );
                          setValidateBooking({
                            ...validateBooking,
                            dateId: date.dateId,
                          });
                          setBookingApproval(false);
                          setBookingError(false);
                        }}
                        className="availableReturnDates"
                      >
                        <span>
                          Departure -
                          {new Date(date.departureDate).toLocaleDateString()}
                        </span>
                        <span>
                          Return -
                          {new Date(date.returnDate).toLocaleDateString()}
                        </span>
                      </li>
                    )}
                  </div>
                ))}
              </ul>

              {selectedDates && (
                <div>
                  <h3>Selected Dates:</h3>
                  <div>
                    <p>
                      Departure:
                      {new Date(
                        selectedDates.departureDate
                      ).toLocaleDateString()}
                      - Return:
                      {new Date(selectedDates.returnDate).toLocaleDateString()}
                    </p>
                    {bookingError && (
                      <span style={{ color: "red" }}>
                        "Available time slots for the desired date and time are
                        already booked choose a different date"
                      </span>
                    )}
                  </div>
                  <div className="bookingReserveContainer">
                    <label className="tourtravellersCount">
                      Travelers Count :
                    </label>
                    <input
                      type="number"
                      onChange={(e) => {
                        setValidateBooking({
                          ...validateBooking,
                          travellerCount: e.target.value,
                        });
                        setBookingApproval(false);
                        setBookingError(false);
                      }}
                      min="1"
                      className="travellersCountInput"
                    />
                    {bookingApproval && validateBooking.travellerCount > 0 ? (
                      <button
                        onClick={() => {
                          localStorage.setItem(
                            "TravellerCount",
                            validateBooking.travellerCount
                          );
                          localStorage.setItem("TourId", tourPackage.tourId);
                          localStorage.setItem("TourPrice", tourPackage.price);
                          navigate("/booking");
                        }}
                        className="tourPackageReserve"
                      >
                        Book Package
                      </button>
                    ) : (
                      <button
                        onClick={handleReservation}
                        className="tourPackageReserve"
                      >
                        Reserve
                      </button>
                    )}
                  </div>
                </div>
              )}
            </div>
          </div>
        </div>
      </div>
      <div className="packageDetailsHighlights">
        <div className="packageDetailsHighlightsDetails">
          <div>
            <h2 className="packageDetailsTitle">Package Details</h2>
            <p>
              Travor is one of the most popular Travel agency for those explore
              the wold and try to make adventure as well as we can beautiful
              destination around the world and make you trip you explore the
              beautiful Maldives with great facilities
            </p>
            <h3 className="HighlightsTitle">Highlights</h3>
            <p>
              Travor is one of the most popular Travel agency for those explore
              the wold and try to make adventure as well as we can beautiful
              destination around the world and make
            </p>
            <ul className="tourPackageHighlights">
              {tourPackage.highlight.map((item, index) => (
                <li key={index}>
                  <span>
                    <img
                      className="tickMark"
                      src={
                        "https://assets.website-files.com/63b261b98057c80332966627/63c77094b962f068a4378bb6_check-mark.svg"
                      }
                    />
                  </span>
                  <span>{item.highlightDetails}</span>
                </li>
              ))}
            </ul>
          </div>
        </div>
        <div className="packageDetailsHighlightsImageContainer">
          <img
            src={
              "https://assets.website-files.com/63b51b3ba52a4df601298f55/63ccca1a1fe6f55b305d2069_package-image%20(13).jpg"
            }
            className="packageDetailsHighlightsImage"
          />
        </div>
      </div>
      <div className="basicInformation">
        <div>
          <h1 className="basicInformationHeading">Basic Information</h1>
          <p>
            Some Basic information about Maldives that can help you a lot when
            you visit so check out all the information before starting your tour
          </p>
        </div>
        <div className="basicInformationTable">
          <div className="basicInformationTableRow">
            <span>Travel Agent Name</span>
            <span>{agentDetails.firstName}</span>
          </div>
          <div className="basicInformationTableRow">
            <span>Agent Email</span>
            <span>{agentDetails.email}</span>
          </div>
          <div className="basicInformationTableRow">
            <span>Agency Name</span>
            <span>{agentDetails.travelAgent.agencyName}</span>
          </div>
          <div className="basicInformationTableRow">
            <span>Food Accommodation</span>
            <span>{tourPackage.foodAccommodation}</span>
          </div>
          <div className="basicInformationTableRow">
            <span>Tour Type</span>
            <span>{tourPackage.tourType}</span>
          </div>
        </div>
      </div>
      <div className="tourPackageInclusion">
        <div className="tourPackageInclusionDetails">
          <div>
            <div className="tourPackageInclusionExclusion">
              <div>
                <h4
                  className={
                    showInclusion
                      ? "includeTitleName"
                      : "includeTitleName inclusionExclusionShade"
                  }
                  onClick={handleShowInclusion}
                >
                  Included
                </h4>
              </div>
              <div>
                <h4
                  className={
                    showExclusion
                      ? "includeTitleName"
                      : "includeTitleName inclusionExclusionShade"
                  }
                  onClick={handleShowExclusion}
                >
                  Not Included
                </h4>
              </div>
            </div>
            <div>
              <div>
                <p>
                  Travor is one of the most popular Travel agency for those
                  explore the wold and try to make adventure as well as
                  webeautiful destination around the world and make Air
                  TicketLunch & DinnerAny kind of product purchesInsuranceAny
                  kind of Ticket
                </p>
              </div>
              <div>
                {showInclusion && (
                  <ul className="tourPackageHighlights">
                    {tourPackage.inclusion.map((item, index) => (
                      <li key={index}>
                        <span>
                          <img
                            className="tickMark"
                            src={
                              "https://assets.website-files.com/63b261b98057c80332966627/63c77094b962f068a4378bb6_check-mark.svg"
                            }
                          />
                        </span>
                        <span>{item.inclusionDetails}</span>
                      </li>
                    ))}
                  </ul>
                )}
                {showExclusion && (
                  <ul className="tourPackageHighlights exclusion">
                    {tourPackage.exclusion.map((item, index) => (
                      <li key={index}>
                        <span>
                          <img
                            className="tickMark"
                            src={
                              "https://assets.website-files.com/63b261b98057c80332966627/63c77094b962f068a4378bb6_check-mark.svg"
                            }
                          />
                        </span>
                        <span>{item.exclusionDetails}</span>
                      </li>
                    ))}
                  </ul>
                )}
              </div>
            </div>
          </div>
        </div>
        <div>
          <img
            src={
              "https://assets.website-files.com/63b261b98057c80332966627/63c792e6dcf6a4ebbe083846_package-include-image.png"
            }
            className="tourPackageInclusionImage"
          />
        </div>
      </div>
      <div className="allTourItineraryDetails">
        <div>
          <h4 className="tourPlanHeading"> Itinerary Details </h4>
        </div>
        {tourPackage.tourItinerary.map((item, index) => (
          <div className="tourPlan" key={index}>
            <div className="tourPlanItirnary">
              <div className="tourPlanDays">
                <div>
                  <div>
                    <h5 className="dayTitle">Day - {index + 1}</h5>
                  </div>
                  <h5 className="tourDayTitle">Title: {item.title}</h5>
                  {item.itineraries.map((itinerary, index) => (
                    <div key={index}>
                      <ul className="dailyActivities">
                        <span>{itinerary.activityTitle}</span>,
                        <span>{itinerary.activityDescription}</span>,
                        <span>{itinerary.location}</span>
                      </ul>
                    </div>
                  ))}
                  <div>
                    <h5 className="stayAccomodation">
                      Stay & Accommodation Details
                    </h5>
                    <span>{item.accommodation.hotelName}</span>,
                    <span>{item.accommodation.address}</span>
                  </div>
                </div>
              </div>
            </div>
            <div className="tourItineraryImage">
              <img
                src={
                  "https://assets.website-files.com/63b261b98057c80332966627/63c8db41cd4253633986638b_tour-plan-image.png"
                }
                className="tourdayImage"
              />
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}

export default TourPackage;
