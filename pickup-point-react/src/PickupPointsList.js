import React, { useEffect, useState } from 'react';
import axios from 'axios';
import "./PickupPoints.css";
import pickup from "./pickup.jpg";

const API_URL = "https://localhost:7226/api/pickuppoints";

const PickupPointsList = () => {
    const [pickupPoints, setPickupPoints] = useState([]);
    const [selectedPoint, setSelectedPoint] = useState(null);
    const [isFormVisible, setIsFormVisible] = useState(false);

    //api download
    useEffect(() => {
        fetchPickupPoints();
    }, []);

    const fetchPickupPoints = async () => {
        try {
            const response = await axios.get(API_URL);
            setPickupPoints(response.data); //save api data
        } catch (error) {
            console.error("Error fetching data:", error.message);
        }
    };

    // delete points
    const handleDelete = async (id) => {
        try {
            await axios.delete(`${API_URL}/${id}`);
            fetchPickupPoints(); // load list
        } catch (error) {
            console.error("Error deleting point:", error.message);
        }
    };

    // add/edit points
    const handleFormSubmit = async (point) => {
        try {
            if (point.id) {
                await axios.put(`${API_URL}/${point.id}`, point);
            } else {
                await axios.post(API_URL, point);
            }
            fetchPickupPoints();
            setIsFormVisible(false); 
        } catch (error) {
            console.error("Error saving point:", error.message);
        }
    };

    // section table
  return (
      <div className="pickup-points-container">
          <img src={pickup} alt="Logo" className="App-logo" />
          <h1>Pickup Points List</h1>

          <table>
              <thead>
                  <tr>
                      <th>Name</th>
                      <th>Address</th>
                      <th>Opening hours</th>
                      <th>Contact numbers</th>
                      <th> <button className="add-button" onClick={() => setIsFormVisible(true)}>Add</button></th>
                  </tr>
              </thead>
              <tbody>
                  {pickupPoints.map((point) => (
                      <tr key={point.id}>
                          <td>{point.name}</td>
                          <td>{point.address}</td>
                          <td>{point.openingHours}</td>
                          <td>{point.contactNumber}</td>
                          <td>
                              <button onClick={() => { setSelectedPoint(point); setIsFormVisible(true); }}>Edit</button>
                              <button onClick={() => handleDelete(point.id)}>Delete</button>
                          </td>
                      </tr>
                  ))}
              </tbody>
          </table>
            {isFormVisible && (
                <PickupPointForm
                    point={selectedPoint}
                    onSave={handleFormSubmit}
                    onCancel={() => { setSelectedPoint(null); setIsFormVisible(false); }}
                />
            )}
        </div>
    );
};

const PickupPointForm = ({ point, onSave, onCancel }) => {
    // Initialize form data state with the provided point or default empty value
    const [formData, setFormData] = useState(
        point || { name: "", address: "", openingHours: "", contactNumber: "" }
    );

    // Handle changes to input fields by updating the corresponding value in formData
    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData((prev) => ({ ...prev, [name]: value }));
    };

    // Handle form submission by calling the onSave callback with the current form data
    const handleSubmit = (e) => {
        e.preventDefault();
        onSave(formData);
    };

    return (
        <div className="form-overlay">
            <form className="pickup-point-form" onSubmit={handleSubmit}>
                <h2>{point ? "Edit" : "Add"}</h2>
                <label>
                    Name:
                    <input
                        type="text"
                        name="name"
                        value={formData.name}
                        onChange={handleChange}
                        required
                    />
                </label>
                <label>
                    Address:
                    <input
                        type="text"
                        name="address"
                        value={formData.address}
                        onChange={handleChange}
                        required
                    />
                </label>
                <label>
                    Opening Hours:
                    <input
                        type="text"
                        name="openingHours"
                        value={formData.openingHours}
                        onChange={handleChange}
                        required
                    />
                </label>
                <label>
                    Contact Number:
                    <input
                        type="text"
                        name="contactNumber"
                        value={formData.contactNumber}
                        onChange={handleChange}
                        required
                    />
                </label>
                <div className="form-buttons">
                    <button type="submit">Save</button>
                    <button type="button" onClick={onCancel}>Cancel</button>
                </div>
            </form>
        </div>
    );
};

export default PickupPointsList;
