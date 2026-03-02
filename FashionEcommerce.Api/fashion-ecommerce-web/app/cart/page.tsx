export default function Cart() {
  return (
    <main className="max-w-5xl mx-auto px-8 py-20">
      <h1 className="text-4xl font-bold mb-10">Your Cart</h1>

      <div className="bg-white p-8 rounded-xl shadow-md">
        <p className="text-gray-600">
          Your cart is currently empty.
        </p>

        <div className="mt-6 border-t pt-6">
          <div className="flex justify-between text-lg font-semibold">
            <span>Total:</span>
            <span>$0.00</span>
          </div>

          <button className="mt-6 w-full bg-black text-white py-3 rounded hover:bg-gray-800 transition">
            Checkout
          </button>
        </div>
      </div>
    </main>
  );
}