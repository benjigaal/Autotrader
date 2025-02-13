import React from 'react'
import { useState } from 'react'

function AddNewCar() {
  const [carData, setCarData] = useState(
    {
      brand: "",
      type: "",
      color: "",
      myear: ""
    })
const handleChange = (event) => {
    const { name, value } = event.target;
    setCarData({ ...carData, [name]: value });
  }

  const handleSubmit = async (event) => 
  {
    const url = "https://localhost:7042/cars"
    event.preventDefault();

    const request = await fetch(url, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(carData),
    });
    if(!request.ok)
    {
       console.log("Hiba")
       return
    }
    const response = await request.json();
    console.log(response.message);
  }

    return (
      <div>
        <form onSubmit={handleSubmit}>
          <label>
            Márka:
            <input type="text" id="brand" name="brand" value={carData.brand} onChange={handleChange} className='form-control' placeholder='Autó márkája'/>
          </label>
          <br></br>
          <label>
            Típus:
            <input type="text" id="type" name="type" value={carData.type} onChange={handleChange} className='form-control' placeholder='Autó típusa'/>
          </label>
          <br></br>
          <label>
            Szín:
            <input type="text" id="color" name="color" value={carData.color} onChange={handleChange} className='form-control' placeholder='Autó színe'/>
          </label>
          <br></br>
          <label>
            Gyártási év:
            <input type="date" id="myear" name="myear" value={carData.myear} onChange={handleChange} className='form-control' placeholder='Autó gyártási év-hónap-nap' />
          </label>
          <br></br>
          <button type="submit" className='btn btn-primary'>Bevitel</button>
        </form>
      </div>
  )
}

export default AddNewCar
