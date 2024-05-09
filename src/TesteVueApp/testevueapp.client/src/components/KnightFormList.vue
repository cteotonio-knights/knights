<template>
    <div id="app" class="container mt-5" style="border: 1px solid red">
        <h1>{{ editMode ? 'Editar' : 'Cadastro de' }} Knight o retorno 4</h1>
        <br />
        <knight-form :knight="selectedKnight" :editMode="editMode" @submit="handleSubmit"></knight-form>
        <p></p>

        <br />
        <p></p>
        <h2>Lista de Knights</h2><br />
        <table class="table" style="border: 1px solid black; width:550px">
            <thead>
                <tr>
                    <th>Nome</th>
                    <th>Idade</th>
                    <th>Armas</th>
                    <th>Atributo</th>
                    <th>Apelido</th>
                    <th>Editar</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="formData in items" :key="formData.id">
                    <td>{{ formData.name }}</td>
                    <td>{{ calculateAge(formData.birthday) }}</td>
                    <td>{{ formData.weapons.length }}</td>
                    <td>{{ formData.keyAttribute }}</td>
                    <td>{{ formData.nickname }}</td>
                    <td><button @click="editKnight(formData)">Editar Apelido</button></td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script lang="ts">
    import KnightForm from './KnightForm.vue';
    import axios from 'axios';

    //type knights = {
    //    id: number,
    //    name: string,
    //    birthday: Date,
    //    keyAttribute: string,
    //    nickname: string,
    //    weapons: weapons
    //}[];

    //type weapons = {
    //    name: string,
    //    mod: number,
    //    attr: string,
    //    equipped: boolean
    //}[];

    export default {
        components: {
            KnightForm
        },
        data() {
            return {
                items: [],
                selectedKnight: {},
                editMode: false
            };
        },
        methods: {
            handleSubmit(knight: any) {
                if (this.editMode) {

                    axios.put('apiknight/' + knight._id, knight)
                        .then(response => {
                            this.carregarLista();
                        })
                        .catch(error => {
                            console.error('Erro ao recuperar a lista de itens:', error);
                        });

                } else {

                    axios.post('apiknight', knight)
                        .then(response => {
                            this.carregarLista();
                        })
                        .catch(error => {
                            console.error('Erro ao recuperar a lista de itens:', error);
                        });

                }
                this.editMode = false;
                this.selectedKnight = {};
            },
            editKnight(formData: any) {
                this.selectedKnight = { ...formData };
                this.editMode = true;
            },
            calculateAge(birthday: any) {
                const today = new Date();
                const birthDate = new Date(birthday);
                let age = today.getFullYear() - birthDate.getFullYear();
                const monthDiff = today.getMonth() - birthDate.getMonth();

                if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < birthDate.getDate())) {
                    age--;
                }

                return age;
            },
            carregarLista() {
                axios.get('http://microsservice_knights:8089/apiknight/')
                    .then(response => {
                        // Atualiza a lista com os itens recebidos da resposta
                        this.items = response.data;
                    })
                    .catch(error => {
                        console.error('Erro ao recuperar a lista de itens:', error);
                    });
            }
        },
        mounted() {
            this.carregarLista();
        }
    };
</script>

<style scoped>
    /* Estilos específicos do componente pai, se necessário */
</style>
