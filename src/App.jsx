import './App.css';
import React from 'react';
import AddNewCar from './components/AddNewCar';
import GetAllCars from './components/GetAllCars';

function App() {
  return (
    <div className="container">
      <AddNewCar />
      <GetAllCars />
    </div>
  );
}

export default App;
