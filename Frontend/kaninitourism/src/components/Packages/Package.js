import React, { useState, useEffect } from "react";
import "../Packages/Package.css";
import { Link } from "react-router-dom";

function Package() {
  const [searchCriteria, setSearchCriteria] = useState({
    destination: "",
    tourType: "",
    date: "",
  });

  const [filteredPackages, setFilteredPackages] = useState([]);
  const [tourPackage, setTourPackage] = useState([
    {
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
    },
  ]);

  useEffect(() => {
    fetch("http://localhost:5129/api/Tour/GetAllTours", {
      method: "GET",
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
        console.log(err);
      });
    const filtered = tourPackage.filter((item) => {
      const matchesDestination =
        item.name
          .toLowerCase()
          .includes(searchCriteria.destination.toLowerCase()) ||
        item.description
          .toLowerCase()
          .includes(searchCriteria.destination.toLowerCase());

      const matchesTourType =
        searchCriteria.tourType === "" ||
        item.tourType === searchCriteria.tourType;

      const matchesDate =
        searchCriteria.date === "" ||
        item.tourDates.some((date) =>
          date.departureDate.includes(searchCriteria.date)
        );

      return matchesDestination && matchesTourType && matchesDate;
    });

    setFilteredPackages(filtered);
  }, [searchCriteria, tourPackage]);

  return (
    <div className="Package">
      <div className="packageHeader">
        <div>
          <h1 className="packageTitle">Our Package</h1>
        </div>
        <div>
          <span className="packageDescription">
            Make Your Trip is one of the most popular Travel agency for those
            who want to explore the world and try to make adventure
          </span>
        </div>
      </div>
      <div className="packageSearch">
        <div className="packageSearchInfo">
          <label className="packageSearchInfoLable">Destination</label>
          <input
            type="text"
            className="packageSearchInfoInputField"
            placeholder="Search Location"
            onChange={(e) =>
              setSearchCriteria({
                ...searchCriteria,
                destination: e.target.value,
              })
            }
          />
        </div>
        <div className="packageSearchInfo">
          <label className="packageSearchInfoLable">Tour Type</label>
          <select
            className="packageSearchInfoInputField"
            onChange={(e) =>
              setSearchCriteria({
                ...searchCriteria,
                tourType: e.target.value,
              })
            }
          >
            <option value="">Select</option>
            <option value="tour type 1">tour type 1</option>
            <option value="tour type 2">tour type 2</option>
            <option value="tour type 3">tour type 3</option>
          </select>
        </div>
        <div className="packageSearchInfo">
          <label className="packageSearchInfoLable">Date</label>
          <input
            type="Date"
            className="packageSearchInfoInputField"
            placeholder="Type Date"
            onChange={(e) =>
              setSearchCriteria({
                ...searchCriteria,
                date: e.target.value,
              })
            }
          />
        </div>
        <div>
          <button className="packageSearchButton">Find Trip</button>
        </div>
      </div>
      <div className="allpackages">
        {filteredPackages.map((item, index) => (
          <div className="packageCardLayOut" key={index}>
            <div>
              <img
                src={
                  "https://assets.website-files.com/63b51b3ba52a4df601298f55/63b658858457f7288f0f8b4a_package-8.jpg"
                }
                className="packageTourImage"
                alt={`Tour ${item.tourId}`}
              />
            </div>
            <div className="packageTourHeadingDays">
              <Link
                to={"/traveller/packagedetails/" + item.tourId}
                className="packageTourHeading"
              >
                {item.name}
              </Link>
              <span>
                {item.numberOfDays} Day {item.numberOfDays - 1} Night
              </span>
            </div>
            <div className="packageTourPrice">
              <div>
                <span className="packageStartFrom">
                  Tour Type - {item.tourType}
                </span>
              </div>
              <div>
                <span className="packageStartFrom">Start from </span>
                <span className="packageStartFromPrice">${item.price}</span>
              </div>
            </div>
          </div>
        ))}
      </div>
      ;
    </div>
  );
}

export default Package;
