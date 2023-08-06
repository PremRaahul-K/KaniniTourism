import React, { useState, useEffect } from "react";
import "../TourPackage/TourPackage.css";

function TourPackage() {
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
  const id = 2;
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
      })
      .catch((err) => {
        console.log(err.error);
      });
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
          <p className="makeMyTripTravelQuote">
            Make your trip is one of the most popular Travel agency for those
            who want to explore the world and try to make adventure
          </p>
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
            <p>
              Travor is one of the most popular Travel agency for those explore
              the wold and try to make adventure as we provide beautiful
              destination around the world and make you trip
            </p>
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
            <div>
              <h4 className="includeTitleName">Included</h4>
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
      <div className="tourPlan">
        <div className="tourPlanItirnary">
          <div>
            <div className="tourPlanDays">
              <div>
                <h4 className="tourPlanHeading">Tour Plan</h4>
              </div>
              {tourPackage.tourItinerary.map((item, index) => (
                <div>
                  <div>
                    <h5 className="dayTitle">Day - 1</h5>
                  </div>
                  <h5 className="tourDayTitle">
                    Visit: The Colosseum and the Arch of Constantine
                  </h5>
                  <ul className="dailyActivities">
                    <li>
                      As the Eiffel Tower is to Paris, the silhouette of the
                    </li>
                    <li>
                      As the Eiffel Tower is to Paris, the silhouette of the
                    </li>
                    <li>
                      As the Eiffel Tower is to Paris, the silhouette of the
                    </li>
                    <li>
                      As the Eiffel Tower is to Paris, the silhouette of the
                    </li>
                  </ul>
                </div>
              ))}
            </div>
          </div>
        </div>
        <div className="tourItineraryImage">
          <img
            src={
              "https://assets.website-files.com/63b261b98057c80332966627/63c8db41cd4253633986638b_tour-plan-image.png"
            }
          />
        </div>
      </div>
    </div>
  );
}

export default TourPackage;
