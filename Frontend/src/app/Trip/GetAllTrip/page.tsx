'use client'
import axios from "axios";
interface Trip {
  TripId: number;
  Destination: string;
  StartDate: string;
  EndDate: string;
  Itinerary: string;
  UserId: number;
}
export default async function GetAllTrip() {
  const res = await axios.get("https://localhost:44315/Trip/GetAll");
  const Trips: Trip[] = await res.data;
  const handleDownload = async (TripId: number) => {
    try {
      const res = await axios.get("https://localhost:44315/Trip/pdf/" + TripId, {
        responseType: "blob",
      });

      if (res.headers['content-type'] !== 'application/pdf') {
        throw new Error('The response is not a valid PDF');
      }

      const pdfBlobUrl = URL.createObjectURL(res.data);

      const link = document.createElement('a');
      link.href = pdfBlobUrl;
      link.download = `Trip_${TripId}.pdf`; 
      link.click();
    } catch (error) {
      console.error("Error downloading PDF:", error);
      alert("Failed to download PDF for Trip " + TripId);
    }
  };

  return (
    <>
      <div className="flex justify-center items-center min-h-screen bg-gray-100">
        <div className="bg-white p-6 rounded-lg shadow-md w-full max-w-5xl">
          <h1 className="text-2xl font-bold mb-6 text-center">List Of Trips</h1>
          <table className="min-w-full border-collapse border border-slate-400">
            <thead>
              <tr className="bg-gray-200">
                <th className="border border-slate-300 px-4 py-2 text-left">Trip ID</th>
                <th className="border border-slate-300 px-4 py-2 text-left">Destination</th>
                <th className="border border-slate-300 px-4 py-2 text-left">Start Date</th>
                <th className="border border-slate-300 px-4 py-2 text-left">End Date</th>
                <th className="border border-slate-300 px-4 py-2 text-left">Itinerary</th>
                <th className="border border-slate-300 px-4 py-2 text-left">User Id</th>
                <th className="border border-slate-300 px-4 py-2 text-left">Action</th>
              </tr>
            </thead>
            <tbody>
              {Trips.map((Trip) => (
                <tr key={Trip.TripId} className="even:bg-gray-50 odd:bg-white">
                  <td className="border border-slate-300 px-4 py-2">{Trip.TripId}</td>
                  <td className="border border-slate-300 px-4 py-2">{Trip.Destination}</td>
                  <td className="border border-slate-300 px-4 py-2">{Trip.StartDate}</td>
                  <td className="border border-slate-300 px-4 py-2">{Trip.EndDate}</td>
                  <td className="border border-slate-300 px-4 py-2">{Trip.Itinerary}</td>
                  <td className="border border-slate-300 px-4 py-2">{Trip.UserId}</td>
                  <td className="border border-slate-300 px-4 py-2">
                    <button
                      onClick={() => handleDownload(Trip.TripId)}
                      className="px-4 py-2 bg-indigo-300 text-black rounded-md hover:bg-indigo-600 transition duration-200"
                    >
                      Download Details
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </>
  );
}
