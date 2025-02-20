import React, { useEffect, useState } from 'react'
import DeleteCar from './DeleteCar'

function GetAllCars(props) {
  const url = "https://localhost:7042/cars"
  const [carData, setCarData] = useState([]);

  useEffect(() => 
  {
    (async () => 
      {
      const request = await fetch(url, {
        headers: {
          "Content-Type": "application/json",
        }
      })
      
      if(!request.ok)
      {
        console.log("Hiba")
        return
      }

      const response = await request.json();
      setCarData(response.result);
      console.log(response.message);
      })()
    }, [props.count]);

    const carElements = carData.map((car) => 
    {
      return (
        <div class="card" style={{'width': 200, 'margin': 10, float: 'left' }} key={car.id}>
          <div class="card-header">{car.brand}</div>
          <div class="card-body">{car.type}</div>
          <div class="card-footer">{car.color}</div>
          <div class="card-footer">{car.myear}</div>
          <div><DeleteCar carId={car.id} handleCount={props.handleCount}/></div>
        </div>
      )
    })

    return (
      <div>
        {carElements}
      </div>
    ) 
}

export default GetAllCars
