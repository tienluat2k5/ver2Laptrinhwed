export default function Home() {
  return (
    <main>
      {/* HERO */}
      <section className="h-screen bg-black text-white flex flex-col items-center justify-center text-center">
        <h1 className="text-6xl font-bold mb-6">
          Elevate Your Style
        </h1>
        <p className="text-lg text-gray-300 mb-8">
          Discover the newest collection
        </p>
        <button className="bg-white text-black px-8 py-3 rounded-full font-semibold hover:bg-gray-200 transition">
          Shop Now
        </button>
      </section>
    </main>
  );
}