import React from "react";

function UpdateCar(props) 
{
    const handleCarData = async() =>
    {
        const url = `https://localhost:7042/cars?id=${props.carId}`
        const request = await fetch(url, {
            method: "PUT",
            body: JSON.stringify(props.carData),
            headers: {
                "Content-Type": "application/json",
              },
        })
        if(!request.ok)
        {
            console.log("Hiba")
            return
        }
        var response = await request.json()
        console.log(response.message)
        props.handleCount()
    }    
    return (
        <button onClick={handleCarData} type='button' className='btn btn-warning'>Módosít</button>        
    )
}

export default UpdateCar