Toxic Comment Classification

This project classifies comments as Toxic or Non-Toxic using Logistic Regression and SVM (SVC) with TF-IDF vectorization. It also provides a FastAPI backend for integration with web applications (e.g., Angular) and a Streamlit UI for testing comments interactively.

🗂 Project Structure
toxic-comment-classification/
│
├─ data/
│   ├─ train.csv
│   └─ validation.csv
│
├─ models/
│   ├─ tfidf_logreg.pkl
│   └─ tfidf_vectorizer.pkl
│
├─ src/
│   ├─ api/
│   │   └─ app.py          # FastAPI backend
│   ├─ models/
│   │   └─ train_baselines.py
│   ├─ data_utils.py       # CSV loader + preprocessing
│   ├─ features.py         # TF-IDF builder
│   └─ app_streamlit.py    # Streamlit UI
│
├─ venv/                   # Python virtual environment
├─ package.json / angular   # Angular frontend (optional)
└─ README.md

⚡ Setup

Clone the repository

git clone <repo_url>
cd toxic-comment-classification


Create virtual environment and activate

python -m venv venv
# Windows
venv\Scripts\activate
# Mac/Linux
source venv/bin/activate


Install Python dependencies

pip install -r requirements.txt


Dependencies include:

scikit-learn

pandas

joblib

fastapi

uvicorn

streamlit

pydantic

nltk

Download NLTK stopwords

import nltk
nltk.download('stopwords')

🏋️ Training the Models

Run the training script to train Logistic Regression and SVC models and save them in the models/ folder.

python -m src.models.train_baselines


✅ Output:

Validation report (LogReg):
accuracy: 0.93 ...
✅ Model and vectorizer saved successfully in 'models' folder.
Validation report (SVC):
accuracy: 0.93 ...
✅ SVC model saved successfully.


This will generate:

models/tfidf_logreg.pkl

models/tfidf_vectorizer.pkl

models/tfidf_svc.pkl

🖥 Streamlit UI

Launch the interactive web UI:

streamlit run src/app_streamlit.py


Open browser at:

http://localhost:8501


Enter a comment in the textbox.

Click Analyze Comment.

See Toxic / Non-Toxic prediction with confidence.

🌐 FastAPI Backend

Start the API server:

uvicorn src.api.app:app --reload


Open browser at:

http://127.0.0.1:8000/


GET / → check if API is running:

{"message": "✅ Toxic Comment Classifier API is running!"}


POST /predict → classify a comment:

Request (JSON)

{
  "text": "You are such a loser!"
}


Response

{
  "text": "You are such a loser!",
  "is_toxic": true,
  "confidence": 0.858
}



change in the requirement.txt 
altair                    5.5.0
annotated-doc             0.0.3
annotated-types           0.7.0
anyio                     4.11.0
attrs                     25.4.0
blinker                   1.9.0
cachetools                6.2.1
certifi                   2025.10.5
charset-normalizer        3.4.4
click                     8.3.0
colorama                  0.4.6
fastapi                   0.120.1
gitdb                     4.0.12
GitPython                 3.1.45
h11                       0.16.0
idna                      3.11
Jinja2                    3.1.6
joblib                    1.5.2
jsonschema                4.25.1
jsonschema-specifications 2025.9.1
MarkupSafe                3.0.3
narwhals                  2.10.0
nltk                      3.9.2
numpy                     2.3.4
packaging                 25.0
pandas                    2.3.3
pillow                    11.3.0
pip                       25.3
protobuf                  6.33.0
pyarrow                   22.0.0
pydantic                  2.12.3
pydantic_core             2.41.4
pydeck                    0.9.1
python-dateutil           2.9.0.post0
python-multipart          0.0.20
pytz                      2025.2
referencing               0.37.0
regex                     2025.10.23
requests                  2.32.5
rpds-py                   0.28.0
scikit-learn              1.7.2
scipy                     1.16.3
six                       1.17.0
smmap                     5.0.2
sniffio                   1.3.1
starlette                 0.49.1
streamlit                 1.50.0
tenacity                  9.1.2
threadpoolctl             3.6.0
toml                      0.10.2
tornado                   6.5.2
tqdm                      4.67.1
typing_extensions         4.15.0
typing-inspection         0.4.2
tzdata                    2025.2
urllib3                   2.5.0
uvicorn                   0.38.0
watchdog                  6.0.0


for run project ml 

python -m src.models.train_baselines

for run api 
uvicorn src.api.app:app --reload
