import React from "react";
import "../Packages/Package.css";

function Package() {
  return (
    <div className="Package">
      <div className="packageHeader">
        <h1 className="packageTitle">Our Package</h1>
        <p className="packageDescription">
          Make Your Trip is one of the most popular Travel agency for those who
          want to explore the world and try to make adventure
        </p>
      </div>
      <div className="packageSearch">
        <div className="packageSearchInfo">
          <label className="packageSearchInfoLable">Destination</label>
          <input
            type="text"
            className="packageSearchInfoInputField"
            placeholder="Search Location"
          />
        </div>
        <div className="packageSearchInfo">
          <label className="packageSearchInfoLable">Tour Type</label>
          <select className="packageSearchInfoInputField">
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
          />
        </div>
        <div className="packageSearchInfo">
          <label className="packageSearchInfoLable">Guest</label>
          <input
            type="number"
            className="packageSearchInfoInputField"
            placeholder="Number Of Guests"
          />
        </div>
        <div>
          <button className="packageSearchButton">Find Trip</button>
        </div>
      </div>
      <div className="packageCardLayOut">
        <div>
          <img
            src={
              "https://assets.website-files.com/63b51b3ba52a4df601298f55/63b658858457f7288f0f8b4a_package-8.jpg"
            }
            className="packageTourImage"
          />
        </div>
        <div className="packageTourHeadingDays">
          <h3 className="packageTourHeading">Spain Tour Package</h3>
          <span>4 Day 3 Night</span>
        </div>
        <div className="packageTourPrice">
          <div>
            <span className="packageStartFrom">Start from </span>
            <span className="packageStartFromPrice">$320</span>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Package;
