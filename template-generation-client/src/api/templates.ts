export interface Template {
    id: string;
    name: string;
    htmlContent: string;
    createdAt: string;
    updatedAt: string;
}

export async function fetchTemplates(): Promise<Template[]> {
    const res = await  fetch("https://localhost:7226/api/templates");
    if (!res.ok) throw new Error("Failed to fetch templates");
    return res.json();
}