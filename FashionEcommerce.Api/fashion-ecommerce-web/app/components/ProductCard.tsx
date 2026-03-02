export default function ProductCard({ id }: { id: number }) {
  return (
    <div className="bg-white rounded-xl shadow-md hover:shadow-xl transition duration-300 overflow-hidden">
      <div className="h-64 bg-gray-200"></div>

      <div className="p-6">
        <h3 className="text-xl font-semibold mb-2">
          Product {id}
        </h3>
        <p className="text-gray-600 mb-4">
          Modern fashion item with premium quality.
        </p>
        <button className="w-full bg-black text-white py-2 rounded hover:bg-gray-800 transition">
          Add to Cart
        </button>
      </div>
    </div>
  );
}