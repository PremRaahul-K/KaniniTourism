import React from "react";
import "../UserHome/UserHome.css";
import Footer from "../Footer/Footer";

function UserHome() {
  return (
    <div className="UserHome">
      <div className="HomeCarousel">
        <div className="hero">
          <div className="WelcomeMessage">
            <h1>Welcome!</h1>
            <p className="WelcomeQute">
              Let’s find your dream Destination make with enjoy
            </p>
            <p>
              Make Your Trip is one of the most popular Travel agency for those
              who want to explore the wold and try to make adventure
            </p>
          </div>
        </div>
      </div>
      <div>
        <Footer />
      </div>
    </div>
  );
}

export default UserHome;
