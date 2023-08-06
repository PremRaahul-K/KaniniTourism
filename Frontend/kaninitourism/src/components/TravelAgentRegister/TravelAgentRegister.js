import React, { useState } from "react";
import "../TravelAgentRegister/TravelAgentRegister.css";
import { useNavigate } from "react-router-dom";
import TravelAgent from "../images/TravelAgent.jpg";

function TravelAgentRegister() {
  const navigate = useNavigate();
  var [user, setUser] = useState({
    email: "",
    userDetail: {
      firstName: "",
      lastName: "",
      gender: "",
      phoneNumber: "",
      address: "",
      dateOfBirth: "",
      nationality: "",
      travelAgent: {
        agencyName: "",
      },
    },
    passwordClear: "",
  });
  const [emailError, setEmailError] = useState("");
  const [passwordError, setPasswordError] = useState("");
  const [agencyError, setAgencyError] = useState("");
  const [nameError, setNameError] = useState("");
  const [dobError, setDOBError] = useState("");

  const validateName = () => {
    if (/^[A-Za-z ]{5,}$/.test(user.userDetail.firstName)) {
      setNameError("");
      return true;
    } else {
      setNameError("Name must contain at least 5 alphabetical characters.");
      return false;
    }
  };

  const validateAgencyName = () => {
    if (/^[A-Za-z ]{5,}$/.test(user.userDetail.agencyName)) {
      setAgencyError("");
      return true;
    } else {
      setAgencyError(
        "Agency Name must contain at least 5 alphabetical characters."
      );
      return false;
    }
  };

  const validateEmail = () => {
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailPattern.test(user.email)) {
      setEmailError("Please enter a valid email address");
      return false;
    }
    setEmailError("");
    return true;
  };

  const validateDOB = () => {
    if (
      /^(19|20)\d\d-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$/.test(
        user.userDetail.dateOfBirth
      )
    ) {
      setDOBError("");
      return true;
    } else {
      setDOBError("Please enter a valid date of birth in YYYY-MM-DD format.");
      return false;
    }
  };

  const validatePassword = () => {
    if (user.passwordClear.length < 4) {
      setPasswordError("Password must be at least 5 characters long");
      return false;
    }
    setPasswordError("");
    return true;
  };

  const handleSubmit = () => {
    if (
      validateEmail() &&
      validateName() &&
      validateAgencyName() &&
      validateDOB() &&
      validatePassword()
    ) {
      fetch("http://localhost:5115/api/TravelAgent/TravelAgentRegister", {
        method: "POST",
        headers: {
          accept: "text/plain",
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ ...user }),
      })
        .then(async (data) => {
          var myData = await data.json();
          localStorage.setItem("id", myData.id);
          localStorage.setItem("role", myData.role);
          localStorage.setItem("token", myData.token);
          if (myData.role == "TravelAgent") {
            navigate("/user");
          }
        })
        .catch((err) => {
          console.log(err.error);
          alert("Invalid Credentials");
        });
    }
  };
  return (
    <div className="TravelAgentRegister">
      <div className="RegisterMessage">
        <div>
          <img src={TravelAgent} className="TravellerLogo" />
        </div>
        <div className="LoginNote">
          <span className="LoginWelcomeMessage">Hello!</span>
          <span className="SignInMessage">
            Please register your account to design travel experiences that
            linger in hearts.
          </span>
        </div>
      </div>
      <div className="RegisterCredentials">
        <div className="UserCredentials">
          <div>
            <h2 className="MakeYourTripLogo">MakeYourTrip</h2>
          </div>
          <div className="UserCredentials">
            <span className="SignInLabel">Travel Agent Register</span>
            <span className="SignInMessage">
              Please enter the following credentials to register.
            </span>
          </div>
          <div className="UserCredentials">
            <label className="RegisterInputLabel">Email ID</label>
            <input
              type="email"
              className="RegisterInputField"
              onBlur={validateEmail}
              placeholder="Email"
              onChange={(event) => {
                validateEmail();
                setUser({ ...user, email: event.target.value });
              }}
            />
            {emailError && <span className="ErrorText">{emailError}</span>}
            <label className="RegisterInputLabel">Agency Name</label>
            <input
              type="text"
              placeholder="Agency Name"
              className="RegisterInputField"
              onBlur={validateAgencyName}
              onChange={(event) => {
                validateAgencyName();
                setUser({
                  ...user,
                  userDetail: {
                    ...user.userDetail,
                    agencyName: event.target.value,
                  },
                });
              }}
            />
            {agencyError && <span className="ErrorText">{agencyError}</span>}
            <label className="RegisterInputLabel">Name</label>
            <input
              type="text"
              placeholder="Name"
              onBlur={validateName}
              onChange={(event) => {
                validateName();
                setUser({
                  ...user,
                  userDetail: {
                    ...user.userDetail,
                    firstName: event.target.value,
                  },
                });
              }}
              className="RegisterInputField"
            />
            {nameError && <span className="ErrorText">{nameError}</span>}
            <div className="registerCredential">
              <div className="genderDobCredential">
                <label className="RegisterInputLabel">Date of Birth</label>
                <input
                  type="Date"
                  placeholder="Date Of Birth"
                  className="RegisterInputField"
                  onBlur={validateDOB}
                  onChange={(event) => {
                    validateDOB();
                    setUser({
                      ...user,
                      userDetail: {
                        ...user.userDetail,
                        dateOfBirth: event.target.value,
                      },
                    });
                  }}
                />
                {dobError && <div style={{ color: "red" }}>{dobError}</div>}
              </div>
              <div className="genderDobCredential">
                <label className="RegisterInputLabel">Gender</label>
                <select
                  className="RegisterInputField genderInput"
                  onChange={(event) => {
                    setUser({
                      ...user,
                      userDetail: {
                        ...user.userDetail,
                        gender: event.target.value,
                      },
                    });
                  }}
                >
                  <option value="">Select</option>
                  <option value="male">Male</option>
                  <option value="female">Female</option>
                  <option value="other">Other</option>
                </select>
              </div>
            </div>
            <label className="RegisterInputLabel">Password</label>
            <input
              type="password"
              className="RegisterInputField"
              onBlur={validatePassword}
              placeholder="Password"
              onChange={(event) => {
                validatePassword();
                setUser({ ...user, passwordClear: event.target.value });
              }}
            />
            {passwordError && (
              <span className="ErrorText">{passwordError}</span>
            )}
            <button className="SignInButton" onClick={handleSubmit}>
              SIGN UP
            </button>
            <div className="LoginBackMessage">
              <span>Have an account?</span>
              <button
                className="LoginButton"
                onClick={() => {
                  navigate("/login");
                }}
              >
                Login
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default TravelAgentRegister;
