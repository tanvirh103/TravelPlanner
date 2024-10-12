'use client'
import axios from "axios";
import { ChangeEvent, SyntheticEvent, useState } from "react";

export default function CreatePacking() {
  const [ItemName, SetItemName] = useState("");
  const [IsPacked, SetIsPacked] = useState<string | null>(null);
  const [TripId, SetTripId] = useState("");
  const [Error, SetError] = useState("");

  const handleItemName = (e: ChangeEvent<HTMLInputElement>) => {
    SetItemName(e.target.value);
  };

  const handleIsPacked = (e: ChangeEvent<HTMLInputElement>) => {
    SetIsPacked(e.target.value === "true" ? "true" : "false");
  };

  const handleTripId = (e: ChangeEvent<HTMLInputElement>) => {
    SetTripId(e.target.value);
  };

  async function PostData() {
    try {
      const formData = new FormData();
      formData.append("ItemName", ItemName);
      formData.append("IsPacked", IsPacked!);
      formData.append("TripId", TripId);
      const res = await axios.post("https://localhost:44315/Packing/Create", formData, {
        headers: { 'Content-Type': 'application/json' }
      });
      const data = res.data;
      console.log(data);
    } catch (Error) {
      console.log(Error);
    }
  }

  const handleSubmit = async (e: SyntheticEvent) => {
    e.preventDefault();
    SetError("");
    if (!ItemName || !IsPacked || !TripId) {
      SetError("All fields are required.");
    } else {
      try {
        PostData();
        SetError("Packing created successfully");
      } catch (Error) {
        console.log(Error);
      }
    }
  };

  return (
    <>
      <div className="flex justify-center items-center min-h-screen bg-gray-100">
        <div className="bg-white p-6 rounded shadow-md w-full max-w-sm">
          <h1 className="text-2xl font-bold mb-4">Create New Packing</h1>
          <form onSubmit={handleSubmit}>
            <div className="mb-4">
              <label htmlFor="ItemName" className="block text-gray-700">Item Name</label>
              <input
                type="text"
                id="ItemName"
                name="ItemName"
                className="w-full px-3 py-2 border rounded"
                value={ItemName}
                onChange={handleItemName}
              />
            </div>

            <div className="mb-4">
              <label className="block text-gray-700">Is Packed</label>
              <div className="flex items-center space-x-4">
                <label className="inline-flex items-center">
                  <input
                    type="radio"
                    name="IsPacked"
                    value="true"
                    className="form-radio"
                    checked={IsPacked === "true"}
                    onChange={handleIsPacked}
                  />
                  <span className="ml-2">Yes</span>
                </label>
                <label className="inline-flex items-center">
                  <input
                    type="radio"
                    name="IsPacked"
                    value="false"
                    className="form-radio"
                    checked={IsPacked === "false"}
                    onChange={handleIsPacked}
                  />
                  <span className="ml-2">No</span>
                </label>
              </div>
            </div>

            <div className="mb-4">
              <label htmlFor="TripId" className="block text-gray-700">Trip Id</label>
              <input
                type="number"
                id="TripId"
                name="TripId"
                className="w-full px-3 py-2 border rounded"
                value={TripId}
                onChange={handleTripId}
              />
            </div>

            {Error && <div className="text-red-500 mb-4">{Error}</div>}
            <button type="submit" className="w-full bg-blue-500 text-white py-2 rounded hover:bg-blue-600">
              Create New Packing
            </button>
          </form>
        </div>
      </div>
    </>
  );
}
