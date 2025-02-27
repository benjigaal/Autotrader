import React, { useEffect, useState } from 'react'
import DeleteCar from './DeleteCar'
import AddNewCar from './AddNewCar';

function GetAllCars(props) {
  const url = "https://localhost:7042/cars"
  const [carData, setCarData] = useState([]);
  const [carObj, setCarObj] = useState(null)

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

    const handleCarObj = (carFromCard) =>
    {
       setCarObj(carFromCard)
       console.log(carFromCard)
    }

    const carElements = carData.map((car) => 
    {
      return (
        <div onDoubleClick={() => {handleCarObj(car)}} class="card" style={{'width': 200, 'margin': 10, float: 'left' }} key={car.id}>
          <div class="card-header">{car.brand}</div>
          <div class="card-body">{car.type}</div>
          <div class="card-footer">{car.color}</div>
          <div class="card-footer">{car.myear}</div>
          <div><DeleteCar carId={car.id} handleCount={props.handleCount}/></div>
        </div>
      )
    })

    return (
      <>
        <AddNewCar handleCount={props.handleCount} carObj={carObj || {}}/>
        <div>
          {carElements}
        </div>
      </>
    ) 
}

export default GetAllCars
