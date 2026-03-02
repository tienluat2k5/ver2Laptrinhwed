import ProductCard from "../components/ProductCard";

export default function Products() {
  return (
    <main className="max-w-7xl mx-auto px-8 py-20">
      <h1 className="text-4xl font-bold mb-12 text-center">
        All Products
      </h1>

      <div className="grid md:grid-cols-3 gap-10">
        {[1, 2, 3, 4, 5, 6].map((item) => (
          <ProductCard key={item} id={item} />
        ))}
      </div>
    </main>
  );
}