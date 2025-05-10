using ProjetoSinistroAPI.MLModels;
using System;
using System.Collections.Generic;

namespace ProjetoSinistroAPI.Services
{
    public interface ISymptomClassificationService
    {
        string PredictDisease(string symptoms);
        string GenerateRecommendation(string disease);
    }

    public class SymptomClassificationService : ISymptomClassificationService
    {
        private readonly Dictionary<string, string> _symptomDiseaseMap = new(StringComparer.OrdinalIgnoreCase)
        {
            { "dor de dente", "Cárie" },
            { "sensibilidade ao frio", "Hipersensibilidade dentária" },
            { "sangramento nas gengivas", "Gengivite" }
        };

        private readonly Dictionary<string, string> _diseaseRecommendationMap = new(StringComparer.OrdinalIgnoreCase)
        {
            { "Cárie", "Agendar consulta com dentista especialista." },
            { "Hipersensibilidade dentária", "Usar creme dental para dentes sensíveis." },
            { "Gengivite", "Visitar um dentista para limpeza." },
            { "Desconhecida", "Agende uma consulta ao dentista." }
        };

        public string PredictDisease(string symptoms)
        {
            foreach (var symptom in _symptomDiseaseMap.Keys)
            {
                if (symptoms.Contains(symptom, StringComparison.OrdinalIgnoreCase))
                {
                    return _symptomDiseaseMap[symptom];
                }
            }
            return "Desconhecida";
        }

        public string GenerateRecommendation(string disease)
        {
            if (_diseaseRecommendationMap.TryGetValue(disease, out var recommendation))
            {
                return recommendation;
            }
            return "Agende uma consulta ao dentista.";
        }
    }
}
